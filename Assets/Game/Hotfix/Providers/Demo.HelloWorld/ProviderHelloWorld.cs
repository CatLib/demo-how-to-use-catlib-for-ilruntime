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

using CatLib;
using Hotfix.API.HelloWorld;

namespace Hotfix.HelloWorld
{
    /// <summary>
    /// Hello World服务
    /// </summary>
    public class ProviderHelloWorld : ServiceProvider
    {
        /// <summary>
        /// 注册Hello World服务
        /// </summary>
        public override void Register()
        {
            App.Singleton<IHelloWorld, ConsoleHelloWorld>();
        }
    }
}