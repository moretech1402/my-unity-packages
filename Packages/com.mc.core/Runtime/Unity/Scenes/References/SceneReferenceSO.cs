using UnityEngine;

namespace MC.Core.Unity.Scenes
{
    // It can be StringReferenceSO to make it more generic but I have preferred clarity
    [CreateAssetMenu(menuName = "Core/Scene Reference")]
    public class SceneReferenceSo : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
    }

}
