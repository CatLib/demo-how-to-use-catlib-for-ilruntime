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
using Hotfix.API.TestsIBindDataOnResolving;
using Hotfix.API.TestsInstance;
using static CatLib.App;

namespace Hotfix.TestsIBindDataOnResolving
{
    public class ProviderIBindDataOnResolving : ServiceProvider
    {
        private int test1;
        private int test2;

        public override void Init()
        {
            Util.Log("Init() : ProviderIBindDataOnResolving");
            Make<IIBindDataOnResolving>();

            if (test1 != 2)
            {
                Util.Faild("IBindDataOnResolving_1");
                return;
            }

            if (test2 != 2)
            {
                Util.Faild("IBindDataOnResolving_2");
                return;
            }

            Util.Success("IBindData_OnResolving");
        }

        public override IEnumerator CoroutineInit()
        {
            Util.Log("CoroutineInit() : ProviderIBindDataOnResolving");
            return base.CoroutineInit();
        }

        public override void Register()
        {
            Util.Log("Register() : ProviderIBindDataOnResolving");
            Singleton<IIBindDataOnResolving, IBindDataOnResolving>()
                .OnResolving<IBindDataOnResolving>((o) =>
            {
                if (o != null)
                {
                    test1++;
                }
            }).OnResolving<IIBindDataOnResolving>((o) =>
            {
                if (o != null)
                {
                    test1++;
                }
            }).OnResolving<IInstance>((o) =>
            {
                if (o != null)
                {
                    test1++;
                }
            }).OnResolving<IBindDataOnResolving>((b, o) =>
            {
                if (o != null && b != null)
                {
                    test2++;
                }
            }).OnResolving<IIBindDataOnResolving>((b, o) =>
            {
                if (o != null && b != null)
                {
                    test2++;
                }
            }).OnResolving<IInstance>((b, o) =>
            {
                if (o != null && b != null)
                {
                    test2++;
                }
            });
        }
    }
}
