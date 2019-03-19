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

namespace Demo.API.Debug
{
    /// <summary>
    /// 调试日志输出接口
    /// </summary>
    public interface IDebug
    {
        /// <summary>
        /// 输出一条调试日志
        /// </summary>
        /// <param name="message">日志消息</param>
        void Log(string message);
    }
}