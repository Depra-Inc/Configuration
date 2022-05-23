using System;
using System.Linq;
using Depra.AssetManagement.Runtime.Manual;
using Depra.AssetManagement.Runtime.Resources;
using Depra.Configuration.Runtime.Attributes;
using UnityEngine;

namespace Depra.Configuration.Runtime.Assets.Provision
{
    public static class ConfigAssetProvider
    {
        private static readonly AssetProvider AssetProvider;
        private static ProvisionConfig _defaults;

        private static void FetchDefaults()
        {
            _defaults ??= (ProvisionConfig)AssetProvider.GetAsset(typeof(ProvisionConfig), ProvisionConfig.ConfigDirectory,
                ProvisionConfig.ConfigName);
        }

        public static ConfigObject GetConfig(Type type)
        {
            FetchDefaults();

            var config = AssetProvider.GetAsset(type, MakeSaveDirectoryPath(), MakeAssetName(type));
            return (ConfigObject)config;
        }

        public static void ClearCache()
        {
            AssetProvider.ClearCache();

            Debug.Log("Config assets cache cleared.");
        }

        static ConfigAssetProvider()
        {
            AssetProvider = new AssetProvider(new AssetLoader(), new AssetFactory());
        }

        private static string MakeSaveDirectoryPath()
        {
            if (_defaults.Directory.EndsWith("/") || _defaults.Directory.EndsWith(@"\"))
            {
                return _defaults.Directory;
            }

            return $@"{_defaults.Directory}\";
        }

        private static string MakeAssetName(Type type)
        {
            var attribute = ConfigAttribute.Find(type);

            var assetName = $"{attribute?.FileName ?? type.Name}";
            var typeNamespace = type.Namespace;

            if (_defaults.AppendNamespaceToFile == false || typeNamespace == null)
            {
                return assetName;
            }

            string append;

            if (_defaults.NameSpaceLength == -1)
            {
                append = typeNamespace;
            }
            else
            {
                var split = typeNamespace.Split('.');

                append = string.Join(".", split.Take(_defaults.NameSpaceLength));
            }

            return $"{append}.{assetName}";
        }
    }
}