/*
 * This file is part of the CatLib package.
 *
 * (c) CatLib <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: https://catlib.io/
 */

using System.Collections;
using CatLib;
using Hotfix.API.TestsIBindDataOnAfterResolving;
using Hotfix.API.TestsInstance;
using static CatLib.App;

namespace Hotfix.TestsIBindDataOnAfterResolving
{
    public class ProviderIBindDataAfterResolving : ServiceProvider
    {
        private int test1;
        private int test2;

        public override void Init()
        {
            Util.Log("Init() : ProviderIBindDataAfterResolving");
            Make<IIBindDataOnAfterResolving>();

            if (test1 != 2)
            {
                Util.Faild("IBindDataOnAfterResolving_1");
                return;
            }

            if (test2 != 2)
            {
                Util.Faild("IBindDataOnAfterResolving_2");
                return;
            }

            Util.Success("IBindData_OnAfterResolving");
        }

        public override IEnumerator CoroutineInit()
        {
            Util.Log("CoroutineInit() : ProviderIBindDataAfterResolving");
            return base.CoroutineInit();
        }

        public override void Register()
        {
            Util.Log("Register() : ProviderIBindDataAfterResolving");
            Singleton<IIBindDataOnAfterResolving, IBindDataOnAfterResolving>()
                .OnAfterResolving<IBindDataOnAfterResolving>((o) =>
                {
                    if (o != null)
                    {
                        test1++;
                    }
                }).OnAfterResolving<IIBindDataOnAfterResolving>((o) =>
                {
                    if (o != null)
                    {
                        test1++;
                    }
                }).OnAfterResolving<IInstance>((o) =>
                {
                    if (o != null)
                    {
                        test1++;
                    }
                }).OnAfterResolving<IBindDataOnAfterResolving>((b, o) =>
                {
                    if (o != null && b != null)
                    {
                        test2++;
                    }
                }).OnAfterResolving<IIBindDataOnAfterResolving>((b, o) =>
                {
                    if (o != null && b != null)
                    {
                        test2++;
                    }
                }).OnAfterResolving<IInstance>((b, o) =>
                {
                    if (o != null && b != null)
                    {
                        test2++;
                    }
                });
        }
    }
}
