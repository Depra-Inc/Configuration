using System.Reflection;
using System.Text.RegularExpressions;
using Depra.Configuration.Runtime.Assets;
using Depra.Configuration.Runtime.Attributes;

namespace Depra.Configuration.Editor.Utils
{
    internal static class ConfigNamingUtility
    {
        public static string GetInspectorName(ConfigObject config)
        {
            var type = config.GetType();
            if (TryGetConfigNameFromAttribute(type, out var configName) == false)
            {
                configName = ReplaceTypeInName(type.Name);
            }

            return AddSpacesForName(configName);
        }

        private static bool TryGetConfigNameFromAttribute(MemberInfo info, out string configName)
        {
            if (info.GetCustomAttribute(typeof(ConfigAttribute)) is ConfigAttribute attribute)
            {
                configName = attribute.DisplayName;
                return true;
            }

            configName = string.Empty;
            return false;
        }

        private static string AddSpacesForName(string rawName)
        {
            return Regex.Replace(rawName, "([a-z])([A-Z])", "$1 $2");
        }

        private static string ReplaceTypeInName(string configName)
        {
            return EditorConfig.Instance.StripConfigTypeFromName
                ? configName.Replace("Config", "")
                : configName;
        }
    }
}