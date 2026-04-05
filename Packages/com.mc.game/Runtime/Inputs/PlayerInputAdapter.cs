using MC.Core;
using MC.Core.Events;
using MC.Core.Unity.Inputs.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MC.Game.Inputs
{
    public class PlayerInputAdapter : MonoBehaviour
    {
        private IEventBus _eventBus;

        private void OnEnable()
        {
            _eventBus = ServiceLocator.Get<IEventBus>();
        }

        public void Move(InputAction.CallbackContext ctx)
            => _eventBus.Publish(new MoveInputEvent() { Value = ctx.ReadValue<Vector2>() });

        public void Jump() => _eventBus.Publish(new JumpInputEvent());

        public void Action(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
                _eventBus.Publish(new ActionInputEvent());
        }

        public void Run(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
                _eventBus.Publish(new RunInputEvent() { IsRunning = true });
            if (ctx.canceled)
                _eventBus.Publish(new RunInputEvent() { IsRunning = false });
        }
    }
}
