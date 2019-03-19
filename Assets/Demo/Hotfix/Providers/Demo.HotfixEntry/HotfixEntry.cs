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

using Demo.API.HotfixEntry;
using Hotfix.API.HelloWorld;

namespace Hotfix.HotfixEntry
{
    /// <summary>
    /// 热更新入口
    /// </summary>
    public class HotfixEntry : IHotfixEntry
    {
        private IHelloWorld HelloWorld { get; set; }

        public HotfixEntry(IHelloWorld helloWorld)
        {
            HelloWorld = helloWorld;
        }

        /// <inheritdoc />
        public void Entry()
        {
            HelloWorld.Say();
        }
    }
}