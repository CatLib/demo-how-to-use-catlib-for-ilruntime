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

namespace Demo.API.HotfixEntry
{
    /// <summary>
    /// 热更新入口
    /// </summary>
    public interface IHotfixEntry
    {
        /// <summary>
        /// 进入热更新程序
        /// </summary>
        void Entry();
    }
}