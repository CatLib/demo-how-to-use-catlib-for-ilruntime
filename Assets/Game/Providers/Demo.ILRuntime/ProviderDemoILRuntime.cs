/*
 * This file is part of the CatLib package.
 *
 * (c) CatLib <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: https://ilruntime.catlib.io/
 */

using CatLib;
using CatLib.ILRuntime;
using Demo.ILRuntime.Loader;
using System.Collections;

namespace Demo.ILRuntime
{
    /// <summary>
    /// 演示用的ILRuntime程序服务
    /// </summary>
    public class ProviderDemoILRuntime : ServiceProvider
    {
        /// <summary>
        /// 初始化ILRuntime服务
        /// </summary>
        public override void Init()
        {
            App.On(ApplicationEvents.OnInited, () =>
            {
                var demoDomain = App.Make<IAppDomain>() as AppDomain;
                if (demoDomain != null)
                {
                    demoDomain.Init("Hotfix.Program.Main");
                }
            });
        }

        /// <summary>
        /// 等待初始化代码
        /// </summary>
        /// <returns></returns>
        public override IEnumerator CoroutineInit()
        {
            if (App.DebugLevel == DebugLevels.Development)
            {
                yield break;
            }

            yield return App.Make<LoaderHotfix>().Start();
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        public override void Register()
        {
            App.Singleton<IAppDomain, AppDomainDemo>().Alias<AppDomainDemo>();
            App.Bind<LoaderHotfix>();
        }
    }
}
