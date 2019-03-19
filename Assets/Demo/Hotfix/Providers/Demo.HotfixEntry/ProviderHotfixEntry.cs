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
using Demo.API.HotfixEntry;

namespace Hotfix.HotfixEntry
{
    /// <summary>
    /// 热更新入口服务
    /// </summary>
    public class ProviderHotfixEntry : ServiceProvider
    {
        /// <inheritdoc />
        public override void Register()
        {
            App.Singleton<IHotfixEntry, HotfixEntry>();
        }
    }
}