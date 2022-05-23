using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Configuration.Runtime.Assets;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Depra.Configuration.Editor.Utils
{
    public static class ConfigIndexer
    {
        [DidReloadScripts]
        private static void OnScriptReload()
        {
            var configType = typeof(ConfigObject);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x =>
                    !x.IsInterface && !x.IsAbstract && x != configType &&
                    configType.IsAssignableFrom(x)).ToList();

            // foreach (var type in types) {
            //     ConfigLoader.Load(type);
            // }

            var guids = AssetDatabase.FindAssets($"t:{typeof(ConfigObject)}");

            var configs = guids.Select(guid =>
                AssetDatabase.LoadAssetAtPath<ConfigObject>(AssetDatabase.GUIDToAssetPath(guid)));

            SetPreloadList(configs);
        }

        private static void SetPreloadList(IEnumerable<ConfigObject> configs)
        {
            var preload = PlayerSettings.GetPreloadedAssets()
                .Where(_ => _ && _ is ConfigObject)
                .ToList();

            var except = configs.Except(preload);
            preload.AddRange(except);

            PlayerSettings.SetPreloadedAssets(preload.ToArray());
        }
    }
}