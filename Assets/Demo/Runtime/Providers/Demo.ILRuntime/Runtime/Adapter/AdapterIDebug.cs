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
using Demo.API.Debug;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntimeAppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace Demo.ILRuntime.Adapter
{
    public class AdapterIDebug : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get { return typeof(IDebug); }
        }

        public override Type[] BaseCLRTypes
        {
            get { return null; }
        }

        public override Type AdaptorType
        {
            get { return typeof(Adaptor); }
        }

        public override object CreateCLRInstance(ILRuntimeAppDomain appdomain, ILTypeInstance instance)
        {
            return new Adaptor(appdomain, instance);
        }

        private class Adaptor : IDebug, CrossBindingAdaptorType
        {
            private readonly ILTypeInstance instance;
            private readonly ILRuntimeAppDomain appdomain;

            private IMethod methodLog;
            private bool methodGotLog;
            private bool isMethodInvokingLog;

            public Adaptor(ILRuntimeAppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance
            {
                get { return instance; }
            }

            public void Log(string message)
            {
                if (!methodGotLog)
                {
                    methodLog = instance.Type.GetMethod("Log", 1);
                    methodGotLog = true;
                }

                if (methodLog == null || isMethodInvokingLog)
                {
                    throw new LogicException("Calling base.Log() in a script is not allowed");
                }

                try
                {
                    isMethodInvokingLog = true;
                    appdomain.Invoke(methodLog, instance, message);
                }
                finally
                {
                    isMethodInvokingLog = false;
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