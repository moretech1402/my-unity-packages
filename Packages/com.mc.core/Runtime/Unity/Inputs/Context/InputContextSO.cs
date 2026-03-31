using UnityEngine;

namespace MC.Core.Unity.Inputs.Context
{
    public interface IInputContextDefinition
    {
        InputContext Context { get; }
    }

    [CreateAssetMenu(menuName = "Core/Unity/Input/Create new Input Context")]
    public class InputContextSo : ScriptableObject, IInputContextDefinition
    {
        public string actionMapName;

        private InputContext _cached;

        public InputContext Context
        {
            get
            {
                _cached ??= new InputContext(actionMapName);
                return _cached;
            }
        }
    }

}
