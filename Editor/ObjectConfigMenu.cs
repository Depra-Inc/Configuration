using Depra.Configuration.Runtime.Assets.Provision;
using UnityEditor;

namespace Depra.Configuration.Editor
{
    internal static class ObjectConfigMenu
    {
        [MenuItem("Tools/Configurations/Open Inspector", priority = 0)]
        public static void Open()
        {
            ObjectConfigWindow.Open();
        }

        [MenuItem("Tools/Configurations/Clear Cache")]
        public static void ClearCache()
        {
            ConfigAssetProvider.ClearCache();
        }
    }
}