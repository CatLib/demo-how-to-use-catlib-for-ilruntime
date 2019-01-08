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

using System.Collections;
using CatLib;
using CatLib.ILRuntime.Loader;

namespace Demo.ILRuntime.Loader
{
    /// <summary>
    /// Hotfix加载器
    /// </summary>
    public class LoaderHotfix
    {
        /// <summary>
        /// AppDomain
        /// </summary>
        private AppDomainDemo Domain { get; set; }

        /// <summary>
        /// Hotfix加载器
        /// </summary>
        /// <param name="domain">AppDomain</param>
        public LoaderHotfix(AppDomainDemo domain)
        {
            Domain = domain;
        }

        /// <summary>
        /// 开始加载热更新代码
        /// </summary>
        /// <returns></returns>
        public IEnumerator Start()
        {
            var loader = new LoaderUnityWebRequest("Hotfix");
            yield return loader.Load();
            
            Domain.LoadAssembly(loader.Dll, loader.Pdb);
        }
    }
}