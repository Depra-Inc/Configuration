using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Depra.Configuration.Editor
{
    public class EditorConfigProvider<T> where T : ScriptableObject
    {
        public T Instance { get; private set; }
        
        public void FetchConfig(string configPath)
        {
            while (true)
            {
                if (Instance != null)
                {
                    return;
                }

                var path = GetConfigPath();
                if (path == null)
                {
                    AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<T>(), configPath);
                    Debug.Log("A config file has been created at the root of your project.<b> " +
                              "You can move this anywhere you'd like.</b>");

                    continue;
                }

                Instance = AssetDatabase.LoadAssetAtPath<T>(path);

                break;
            }
        }

        public string GetConfigPath()
        {
            var paths = AssetDatabase.FindAssets(nameof(T))
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(config => config.EndsWith(".asset")).ToList();

            if (paths.Count > 1)
            {
                Debug.LogWarning("Multiple config assets found. Delete one.");
            }

            return paths.FirstOrDefault();
        }
    }

}