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
using ILRuntime.Runtime.Generated;

namespace Demo.ILRuntime
{
    /// <summary>
    /// 演示用的AppDomain
    /// </summary>
    public class AppDomainDemo : AppDomain
    {
        /// <summary>
        /// 构造一个演示用的AppDomain
        /// </summary>
        /// <param name="application">应用程序</param>
        /// <param name="debugLevel">调试等级</param>
        public AppDomainDemo(IApplication application, DebugLevels debugLevel)
            : base(application, debugLevel)
        {
            Adapter.RegisterAdapter.Register(Domain);
            CLRBindings.Initialize(Domain);
        }

        /// <summary>
        /// 调用入口函数
        /// </summary>
        /// <param name="main"></param>
        protected override void CallMain(string main)
        {
#if UNITY_EDITOR
            if (DebugLevel == DebugLevels.Development)
            {
                var application = Application as ILRuntimeApplication;
                if (application != null)
                {
                    application.DeferInitServiceProvider(
                        () =>
                        {
                            Hotfix.Program.Main(Application);
                        });
                    return;
                }
                Hotfix.Program.Main(Application);
                return;
            }
#endif
            base.CallMain(main);
        }
    }
}