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

using Demo.API.Debug;

namespace Hotfix.Debug
{
    /// <summary>
    /// 热更新Debug实现
    /// </summary>
    public class HotfixDebug : IDebug
    {
        /// <inheritdoc />
        public void Log(string message)
        {
            UnityEngine.Debug.Log("[HotFix] :" + message);
        }
    }
}