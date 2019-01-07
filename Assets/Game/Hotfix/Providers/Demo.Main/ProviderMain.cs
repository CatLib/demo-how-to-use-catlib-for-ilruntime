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
using Demo.API.ILRuntime;

namespace Demo.Main
{
    /// <summary>
    /// 入口服务
    /// </summary>
    public class ProviderMain : ServiceProvider
    {
        /// <summary>
        /// 注册入口服务
        /// </summary>
        public override void Register()
        {
            App.Singleton<IMain, Main>();
        }
    }
}