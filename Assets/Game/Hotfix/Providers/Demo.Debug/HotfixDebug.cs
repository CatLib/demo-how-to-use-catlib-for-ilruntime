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

namespace Demo.Debug
{
    /// <summary>
    /// 热更新调试
    /// </summary>
    public class HotfixDebug : IDebug
    {
        /// <summary>
        /// 输出一条调试日志
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Log(string message)
        {
            UnityEngine.Debug.Log("[HotFix] :" + message);
        }
    }
}