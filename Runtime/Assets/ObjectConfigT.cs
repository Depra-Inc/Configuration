using System;

namespace Depra.Configuration.Runtime.Assets
{
    /// <summary>
    /// Has single cached instance.
    /// </summary>
    /// <typeparam name="T">Inherited type</typeparam>
    public abstract class ConfigObject<T> : ConfigObject where T : ConfigObject<T>
    {
        private static T _internalInstance;
        private static readonly Type TypeCache = typeof(T);

        /// <summary>
        /// Cached instance of config, for avoiding expensive GetConfig();
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_internalInstance == null)
                {
                    _internalInstance = GetConfig(TypeCache) as T;
                }

                return _internalInstance;
            }
        }
    }
}