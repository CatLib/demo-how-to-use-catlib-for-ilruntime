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
using Demo.API.UI;
using Hotfix.API.HelloWorld;

namespace Hotfix.UI
{
    /// <summary>
    /// UI服务
    /// </summary>
    public class UIManager : IUI
    {
        /// <summary>
        /// Hello World服务
        /// </summary>
        private IHelloWorld HelloWorld { get; set; }

        /// <summary>
        /// 构建一个入口服务
        /// </summary>
        /// <param name="helloWorld">Hello World服务</param>
        public UIManager(IHelloWorld helloWorld)
        {
            HelloWorld = helloWorld;
        }

        /// <summary>
        /// 打开一个UI
        /// </summary>
        /// <param name="name">UI的名字</param>
        public void Open(string name)
        {
            HelloWorld.Say();
        }
    }
}