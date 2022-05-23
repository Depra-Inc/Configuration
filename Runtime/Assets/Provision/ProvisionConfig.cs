using System;
using Depra.Configuration.Runtime.Attributes;
using UnityEngine;

namespace Depra.Configuration.Runtime.Assets.Provision
{
    [SpecialConfig]
    [Config(DisplayName = "Provision")]
    public class ProvisionConfig : ConfigObject<ProvisionConfig>
    {
        [SerializeField] private string _directory = "Configs";
        [SerializeField] private bool _appendNamespaceToFile;
        [SerializeField] private int _nameSpaceLength = -1;
        
        internal static string ConfigDirectory => "Configs";
        internal static string ConfigName => $"{TypeCache}";

        private static readonly Type TypeCache = typeof(ProvisionConfig);
        
        public string Directory => _directory;
        public bool AppendNamespaceToFile => _appendNamespaceToFile;
        public int NameSpaceLength => _nameSpaceLength;
    }
}
