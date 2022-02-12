using System;
using System.IO;
using Depra.Configuration.Runtime.SO;
using Depra.Toolkit.Singletons.Runtime.Unity.Utils;

namespace Depra.Configuration.Runtime.Factory
{
    public class ObjectConfigFactory : ScriptableObjectFactory<ObjectConfig>, IConfigFactory
    {
        private const string Directory = "Configs/";

        public ObjectConfig CreateAndLoad(Type type)
        {
            var fullPath = Path.Combine(Directory, type.Name);
            return CreateAndLoad(type, fullPath);
        }
    }
}