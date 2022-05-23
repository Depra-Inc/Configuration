using System;
using Depra.Configuration.Runtime.Assets.Provision;
using UnityEngine;

namespace Depra.Configuration.Runtime.Assets
{
    public abstract class ConfigObject : ScriptableObject
    {
        public static ConfigObject GetConfig(Type type)
        {
            return ConfigAssetProvider.GetConfig(type);
        }
    }
}