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

namespace Demo.ILRuntime
{
    /// <summary>
    /// 演示用的ILRuntime程序服务
    /// </summary>
    public class ProviderDemoILRuntime : ServiceProvider
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        public override void Register()
        {
            App.Singleton<IAppDomain, DemoAppDomain>();
        }
    }
}
