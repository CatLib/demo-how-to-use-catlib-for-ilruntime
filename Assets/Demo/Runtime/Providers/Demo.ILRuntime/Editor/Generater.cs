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

using ILRuntime.Runtime.CLRBinding;
using System;
using System.Collections.Generic;
using Demo.API.Debug;
using Demo.API.UI;
using UnityEditor;
using UnityEngine;

namespace CatLib.ILRuntime
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public class Generater : MonoBehaviour
    {
        [MenuItem("CatLib/Generater/Generate CLR Binding Code")]
        public static void GenerateCLRBinding()
        {
            var types = new List<Type>
            {
                typeof(IUI),
                typeof(IDebug)
            };

            BindingCodeGenerator.GenerateBindingCode(types, "Assets/Demo/Runtime/Providers/Demo.ILRuntime/Generated/CLR");
        }
    }
}

