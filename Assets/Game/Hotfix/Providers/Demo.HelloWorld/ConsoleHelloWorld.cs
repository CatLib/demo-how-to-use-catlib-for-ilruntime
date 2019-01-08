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
using Hotfix.API.HelloWorld;

namespace Hotfix.HelloWorld
{
    /// <summary>
    /// Hello World
    /// </summary>
    public class ConsoleHelloWorld : IHelloWorld
    {
        /// <summary>
        /// 调试器
        /// </summary>
        private IDebug Debug { get; set; }

        /// <summary>
        /// 构建一个Hello World
        /// </summary>
        /// <param name="debug"></param>
        public ConsoleHelloWorld(IDebug debug)
        {
            Debug = debug;
        }

        /// <summary>
        /// Say Hello World
        /// </summary>
        public void Say()
        {
            Debug.Log("hello world");
        }
    }
}