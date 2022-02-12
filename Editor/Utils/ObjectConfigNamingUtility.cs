using System.Reflection;
using System.Text.RegularExpressions;
using Depra.Configuration.Runtime.Attributes;
using Depra.Configuration.Runtime.SO;

namespace Depra.Configuration.Editor.Utils
{
    internal static class ObjectConfigNamingUtility
    {
        internal static string GetInspectorName(ObjectConfig config)
        {
            var type = config.GetType();
            if (TryGetConfigNameFromAttribute(type, out var configName) == false)
            {
                configName = type.Name;
            }

            var nameWithSpaces = Regex.Replace(configName, "([a-z])([A-Z])", "$1 $2");

            return EditorConfig.Instance.StripConfigTypeFromName
                ? nameWithSpaces.Replace("Config", "")
                : nameWithSpaces;
        }

        private static bool TryGetConfigNameFromAttribute(MemberInfo info, out string configName)
        {
            if (info.GetCustomAttribute(typeof(ConfigAttribute)) is ConfigAttribute attribute)
            {
                configName = attribute.Name;
                return true;
            }

            configName = string.Empty;
            return false;
        }
    }
}