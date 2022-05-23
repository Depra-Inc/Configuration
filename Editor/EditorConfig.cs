using Depra.Configuration.Runtime.Assets;
using Depra.Configuration.Runtime.Attributes;
using UnityEngine;

namespace Depra.Configuration.Editor
{
    [SpecialConfig]
    [Config(DisplayName = "Editor", OrderId = 1)]
    public class EditorConfig : ConfigObject<EditorConfig>
    {
        [SerializeField] private bool _stripTypeFromName = true;
        [SerializeField] private Color _validColor = Color.green;
        [SerializeField] private Color _invalidColor = Color.red;
        [SerializeField] private Color _normalColor = Color.white;

        public bool StripConfigTypeFromName => _stripTypeFromName;
        
        public Color ValidColor => _validColor;
        public Color InvalidColor => _invalidColor;
        public Color NormalColor => _normalColor;
    }
}