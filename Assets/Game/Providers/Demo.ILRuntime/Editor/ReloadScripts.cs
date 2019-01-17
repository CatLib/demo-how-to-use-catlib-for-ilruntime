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

using System.IO;
using UnityEditor;

namespace CatLib.ILRuntime
{
    public class ReloadScripts
    {
        private static string DllName = "Hotfix";

        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            var source = UnityEngine.Application.dataPath + "/../Library/ScriptAssemblies/";
            var target = UnityEngine.Application.streamingAssetsPath + "/";

            File.Copy(source + DllName + ".dll", target + DllName + ".dll", true);
            File.Copy(source + DllName + ".pdb", target + DllName + ".pdb", true);

            AssetDatabase.Refresh();
        }
    }
}