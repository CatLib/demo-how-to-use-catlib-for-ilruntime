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
using Hotfix.Debug;
using Hotfix.HelloWorld;
using Hotfix.UI;

namespace Hotfix
{
    /// <summary>
    /// 项目注册的服务提供者
    /// </summary>
    public static class Providers
    {
        /// <summary>
        /// 项目注册的服务提供者
        /// </summary>
        public static IServiceProvider[] ServiceProviders => new IServiceProvider[]
        {
        	new ProviderUI(),
            new ProviderDebug(),
            new ProviderHelloWorld()
        };
    }
}