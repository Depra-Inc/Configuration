using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Configuration.Runtime.Assets;

namespace Depra.Configuration.Editor.Utils
{
    internal static class ConfigAssetFinder
    {
        /// <summary>
        /// Gets all configs in the assembly (also creates if there are none).
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ConfigObject> FindAllConfigs()
        {
            return FindConfigs(type =>
                type.IsClass && type.IsAbstract == false && type.IsSubclassOf(typeof(ConfigObject)));
        }

        public static IEnumerable<T> FindAllConfigs<T>() where T : ConfigObject<T>
        {
            return from domain in AppDomain.CurrentDomain.GetAssemblies()
                from type in domain.GetTypes()
                where type.IsClass && type.IsAbstract == false && type.IsSubclassOf(typeof(ConfigObject<T>))
                select ConfigObject<T>.Instance;
        }

        private static IEnumerable<ConfigObject> FindConfigs(Predicate<Type> predicate)
        {
            return from domain in AppDomain.CurrentDomain.GetAssemblies()
                from type in domain.GetTypes()
                where predicate.Invoke(type)
                select ConfigObject.GetConfig(type);
        }
    }
}