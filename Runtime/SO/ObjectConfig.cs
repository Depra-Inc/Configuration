using System;
using Depra.Configuration.Runtime.Factory;
using UnityEngine;

namespace Depra.Configuration.Runtime.SO
{
    public abstract class ObjectConfig : ScriptableObject
    {
        private static readonly IConfigFactory Factory;

        public static ObjectConfig GetConfig(Type type)
        {
            return Factory.CreateAndLoad(type);
        }

        static ObjectConfig()
        {
            Factory = new ObjectConfigFactory();
        }
    }
}