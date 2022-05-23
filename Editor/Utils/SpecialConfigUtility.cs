using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Depra.Configuration.Runtime.Assets;
using Depra.Configuration.Runtime.Attributes;

namespace Depra.Configuration.Editor.Utils
{
    internal static class SpecialConfigUtility
    {
        public static IEnumerable<ConfigObject> GetConfigsWithSpecialAttribute(IEnumerable<ConfigObject> configs)
        {
            return (from config in configs
                let type = config.GetType()
                where type.GetCustomAttribute(typeof(SpecialConfigAttribute)) != null
                select config).ToList();
        }
    }
}