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

using Demo.API.ILRuntime;
using Hotfix.API.HelloWorld;

namespace Demo.Main
{
    /// <summary>
    /// 入口服务
    /// </summary>
    public class Main : IMain
    {
        /// <summary>
        /// Hello World服务
        /// </summary>
        private IHelloWorld HelloWorld { get; set; }

        /// <summary>
        /// 构建一个入口服务
        /// </summary>
        /// <param name="helloWorld">Hello World服务</param>
        public Main(IHelloWorld helloWorld)
        {
            HelloWorld = helloWorld;
        }

        /// <summary>
        /// 启动热更新服务
        /// </summary>
        public void Start()
        {
            HelloWorld.Say();
        }
    }
}