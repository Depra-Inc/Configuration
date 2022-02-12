using UnityEditor;

namespace Depra.Configuration.Editor
{
    internal static class ObjectConfigMenu
    {
        [MenuItem("Tools/Configurations", priority = 0)]
        public static void Open()
        {
            ObjectConfigWindow.Open();
        }
    }
}