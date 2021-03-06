﻿/*
 * This file is part of the CatLib package.
 *
 * (c) CatLib <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: https://ilruntime.catlib.io/
 */

namespace Hotfix.API.HelloWorld
{
    /// <summary>
    /// 热更新内部的 Hello World 接口，这个接口无法被主程序访问。
    /// </summary>
    public interface IHelloWorld
    {
        /// <summary>
        /// Say Hello World
        /// </summary>
        void Say();
    }
}

