/*
 * This file is part of the CatLib package.
 *
 * (c) CatLib <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using CatLib;
using CatLib.ILRuntime;
using Demo.API.UI;
using UnityEngine;
using Application = CatLib.Application;

namespace Game
{
    /// <summary>
    /// 项目入口
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class Main : Framework
    {
        /// <summary>
        /// 项目入口
        /// </summary>
        protected override void OnStartCompleted()
        {
            var a = App.Make<IUI>();
            a.Open("login");
        }

        /// <summary>
        /// 创建应用程序实例
        /// </summary>
        /// <param name="debugLevel">调试等级</param>
        /// <returns>应用程序实例</returns>
        protected override Application CreateApplication(DebugLevels debugLevel)
        {
            return new ILRuntimeApplication(this)
            {
                DebugLevel = debugLevel
            };
        }

        /// <summary>
        /// 获取引导程序
        /// </summary>
        /// <returns>引导脚本</returns>
        protected override IBootstrap[] GetBootstraps()
        {
            return Arr.Merge(base.GetBootstraps(), Bootstraps.Bootstrap);
        }
    }
}
