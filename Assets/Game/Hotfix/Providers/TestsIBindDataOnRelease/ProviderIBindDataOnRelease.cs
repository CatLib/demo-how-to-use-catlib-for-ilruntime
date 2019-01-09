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
using Hotfix.API.TestsIBindDataOnRelease;
using Hotfix.API.TestsInstance;
using static CatLib.App;

namespace Hotfix.TestsIBindDataOnRelease
{
    public class ProviderIBindDataOnRelease : ServiceProvider
    {
        private int test1;
        private int test2;

        public override void Init()
        {
            Util.Log("Init() : ProviderIBindDataOnRelease");
            Make<IIBindDataOnRelease>();
            Release<IIBindDataOnRelease>();

            if (test1 != 2)
            {
                Util.Faild("IBindDataOnRelease_1");
                return;
            }

            if (test2 != 2)
            {
                Util.Faild("IBindDataOnRelease_2");
                return;
            }

            Util.Success("IBindData_OnRelease");
        }

        public override IEnumerator CoroutineInit()
        {
            Util.Log("CoroutineInit() : ProviderIBindDataOnRelease");
            return base.CoroutineInit();
        }

        public override void Register()
        {
            Util.Log("Register() : ProviderIBindDataOnRelease");
            Singleton<IIBindDataOnRelease, IBindDataOnRelease>()
                .OnRelease<IBindDataOnRelease>((o) =>
                {
                    if (o != null)
                    {
                        test1++;
                    }
                }).OnRelease<IIBindDataOnRelease>((o) =>
                {
                    if (o != null)
                    {
                        test1++;
                    }
                }).OnRelease<IInstance>((o) =>
                {
                    if (o != null)
                    {
                        test1++;
                    }
                }).OnRelease<IBindDataOnRelease>((b, o) =>
                {
                    if (o != null && b != null)
                    {
                        test2++;
                    }
                }).OnRelease<IIBindDataOnRelease>((b, o) =>
                {
                    if (o != null && b != null)
                    {
                        test2++;
                    }
                }).OnRelease<IInstance>((b, o) =>
                {
                    if (o != null && b != null)
                    {
                        test2++;
                    }
                });
        }
    }
}
