using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class Demo_API_HotfixEntry_IHotfixEntry_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(Demo.API.HotfixEntry.IHotfixEntry);
            args = new Type[]{};
            method = type.GetMethod("Entry", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Entry_0);



            app.RegisterCLRCreateArrayInstance(type, s => new Demo.API.HotfixEntry.IHotfixEntry[s]);


        }


        static StackObject* Entry_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            Demo.API.HotfixEntry.IHotfixEntry instance_of_this_method = (Demo.API.HotfixEntry.IHotfixEntry)typeof(Demo.API.HotfixEntry.IHotfixEntry).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Entry();

            return __ret;
        }





    }
}
