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

using System;
using CatLib;
using Demo.API.UI;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace Demo.ILRuntime.Adapter
{
    public class AdapterIUI : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get { return typeof(IUI); }
        }

        public override Type[] BaseCLRTypes
        {
            get { return null; }
        }

        public override Type AdaptorType
        {
            get { return typeof(Adaptor); }
        }

        public override object CreateCLRInstance(AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adaptor(appdomain, instance);
        }

        private class Adaptor : IUI, CrossBindingAdaptorType
        {
            private readonly ILTypeInstance instance;
            private readonly AppDomain appdomain;

            private IMethod methodOpen;
            private bool methodGotOpen;
            private bool isMethodInvokingOpen;

            public Adaptor(AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance
            {
                get { return instance; }
            }

            public void Open(string name)
            {
                if (!methodGotOpen)
                {
                    methodOpen = instance.Type.GetMethod("Open", 1);
                    methodGotOpen = true;
                }

                if (methodOpen == null || isMethodInvokingOpen)
                {
                    throw new LogicException("Calling base.Open() in a script is not allowed");
                }

                try
                {
                    isMethodInvokingOpen = true;
                    appdomain.Invoke(methodOpen, instance, name);
                }
                finally
                {
                    isMethodInvokingOpen = false;
                }
            }

            public override string ToString()
            {
                var method = appdomain.ObjectType.GetMethod("ToString", 0);
                method = instance.Type.GetVirtualMethod(method);
                if (method == null || method is ILMethod)
                {
                    return instance.ToString();
                }
                return instance.Type.FullName;
            }
        }
    }
}