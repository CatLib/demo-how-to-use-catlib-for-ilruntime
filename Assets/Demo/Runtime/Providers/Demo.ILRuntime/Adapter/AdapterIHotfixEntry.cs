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
using Demo.API.HotfixEntry;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace Demo.ILRuntime.Adapter
{
    public class AdapterIHotfixEntry : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get { return typeof(IHotfixEntry); }
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

        private class Adaptor : IHotfixEntry, CrossBindingAdaptorType
        {
            private readonly ILTypeInstance instance;
            private readonly AppDomain appdomain;

            private IMethod methodEntry;
            private bool methodGotEntry;
            private bool isMethodInvokingEntry;

            public Adaptor(AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance
            {
                get { return instance; }
            }

            public void Entry()
            {
                if (!methodGotEntry)
                {
                    methodEntry = instance.Type.GetMethod("Entry", 0);
                    methodGotEntry = true;
                }

                if (methodEntry == null || isMethodInvokingEntry)
                {
                    throw new LogicException("Calling base.Entry() in a script is not allowed");
                }

                try
                {
                    isMethodInvokingEntry = true;
                    appdomain.Invoke(methodEntry, instance);
                }
                finally
                {
                    isMethodInvokingEntry = false;
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