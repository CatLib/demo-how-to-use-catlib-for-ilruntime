/*
 * This file is part of the CatLib package.
 *
 * (c) CatLib <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: https://catlib.io/
 */

using System;
using System.Collections;
using System.IO;
using UnityEngine.Networking;

namespace CatLib.ILRuntime.Loader
{
    /// <summary>
    /// UnityWebRequest加载器
    /// </summary>
    internal sealed class LoaderUnityWebRequest : IDisposable
    {
        /// <summary>
        /// 是否已经完成
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Dll数据
        /// </summary>
        public Stream Dll { get; set; }

        /// <summary>
        /// Pdb数据
        /// </summary>
        public Stream Pdb { get; set; }

        /// <summary>
        /// 下载路径
        /// </summary>
        private readonly string path;

        /// <summary>
        /// 构建一个Assembly加载器
        /// </summary>
        /// <param name="path">下载路径</param>
        public LoaderUnityWebRequest(string path)
        {
            IsDone = false;
            this.path = path;
        }

        /// <summary>
        /// 加载指定的资源
        /// </summary>
        /// <returns></returns>
        public IEnumerator Load()
        {
            using (var www = UnityWebRequest.Get(GetLoadPath(path) + ".dll"))
            {
                yield return www.SendWebRequest();
                if (!string.IsNullOrEmpty(www.error))
                {
                    throw new LogicException("Cannot Load Assembly : " + www.error);
                }

                Dll = new MemoryStream(www.downloadHandler.data);
            }

            var pdb = GetLoadPath(path) + ".pdb";

            if (File.Exists(pdb))
            {
                using (var www = UnityWebRequest.Get(pdb))
                {
                    yield return www.SendWebRequest();
                    if (!string.IsNullOrEmpty(www.error))
                    {
                        throw new LogicException("Cannot Load Assembly : " + www.error);
                    }

                    Pdb = new MemoryStream(www.downloadHandler.data);
                }
            }

            IsDone = true;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (Dll != null)
            {
                Dll.Dispose();
            }

            if (Pdb != null)
            {
                Pdb.Dispose();
            }
        }

        /// <summary>
        /// 获取加载路径
        /// </summary>
        /// <param name="file">文件名</param>
        /// <returns>加载路径</returns>
        private string GetLoadPath(string file)
        {
#if UNITY_ANDROID
            return UnityEngine.Application.streamingAssetsPath + "/" + file;
#else
            return "file:///" + UnityEngine.Application.streamingAssetsPath + "/" + file;
#endif
        }
    }
}