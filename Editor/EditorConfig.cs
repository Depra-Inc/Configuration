using Depra.Configuration.Runtime.Attributes;
using Depra.Configuration.Runtime.SO;
using NaughtyAttributes;
using UnityEngine;

namespace Depra.Configuration.Editor
{
    [Config("Editor", 1)]
    public class EditorConfig : ObjectConfig<EditorConfig>
    {
        [field: SerializeField, BoxGroup] public bool StripConfigTypeFromName { get; private set; } = true;

        [field: SerializeField, BoxGroup] public Color ValidColor { get; private set; } = Color.green;

        [field: SerializeField, BoxGroup] public Color InvalidColor { get; private set; } = Color.red;

        [field: SerializeField, BoxGroup] public Color NormalColor { get; private set; } = Color.white;
    }
}