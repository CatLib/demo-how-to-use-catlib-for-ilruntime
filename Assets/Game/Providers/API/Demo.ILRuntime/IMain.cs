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

namespace Demo.API.ILRuntime
{
    /// <summary>
    /// 热更新入口服务
    /// </summary>
    public interface IMain
    {
        /// <summary>
        /// 启动热更新服务
        /// </summary>
        void Start();
    }
}