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

using CatLib;
using Hotfix.TestsAlias;
using Hotfix.TestsBind;
using Hotfix.TestsBindIf;
using Hotfix.TestsCanMake;
using Hotfix.TestsExtend;
using Hotfix.TestsFactory;
using Hotfix.TestsGetBind;
using Hotfix.TestsHasBind;
using Hotfix.TestsHasInstance;
using Hotfix.TestsInstance;
using Hotfix.TestsIsAlias;
using Hotfix.TestsIsResolved;
using Hotfix.TestsIsStatic;
using Hotfix.TestsMake;
using Hotfix.TestsOnAfterResolving;
using Hotfix.TestsOnRelease;
using Hotfix.TestsOnResolving;
using Hotfix.TestsRelease;
using Hotfix.TestsSingleton;
using Hotfix.TestsSingletonIf;
using Hotfix.TestsTag;
using Hotfix.TestsUnbind;
using Hotfix.TestsWatch;
using Hotfix.Type2Service;
using Hotfix.Debug;
using Hotfix.HelloWorld;
using Hotfix.TestsIBindDataOnAfterResolving;
using Hotfix.TestsIBindDataOnRelease;
using Hotfix.TestsIBindDataOnResolving;
using Hotfix.UI;

namespace Hotfix
{
    /// <summary>
    /// 项目注册的服务提供者
    /// </summary>
    public static class Providers
    {
        /// <summary>
        /// 项目注册的服务提供者
        /// </summary>
        public static IServiceProvider[] ServiceProviders => new IServiceProvider[]
        {
        	new ProviderUI(),
            new ProviderDebug(),
            new ProviderHelloWorld(),
            new ProviderHasInstance(),
            new ProviderGetBind(),
            new ProviderIsResolved(),
            new ProviderHasBind(),
            new ProviderCanMake(),
            new ProviderIsStatic(),
            new ProviderIsAlias(),
            new ProviderAlias(),
            new ProviderExtend(),
            new ProviderBind(),
            new ProviderBindIf(),
            new ProviderSingleton(),
            new ProviderSingletonIf(),
            new ProviderUnbind(),
            new ProviderTag(),
            new ProviderInstance(),
            new ProviderRelease(),
            new ProviderMake(),
            new ProviderFactory(),
            new ProviderOnRelease(),
            new ProviderOnResolving(),
            new ProviderOnAfterResolving(),
            new ProviderWatch(),
            new ProviderTypeToService(),
            new ProviderIBindDataOnResolving(), 
            new ProviderIBindDataAfterResolving(),
            new ProviderIBindDataOnRelease()
        };
    }
}