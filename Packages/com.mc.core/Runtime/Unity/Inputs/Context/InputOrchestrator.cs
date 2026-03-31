using MC.Core.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MC.Core.Unity.Inputs.Context
{
    public struct InputContextChangedEvent
    {
        public InputContext Context;
    }

    public sealed class InputOrchestrator : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        private IEventBus _eventBus;

        private void Awake()
        {
            _eventBus.Subscribe<InputContextChangedEvent>(OnContextChanged);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<InputContextChangedEvent>(OnContextChanged);
        }

        private void OnContextChanged(InputContextChangedEvent evt)
        {
            playerInput.SwitchCurrentActionMap(evt.Context.Id);
        }
    }
}
