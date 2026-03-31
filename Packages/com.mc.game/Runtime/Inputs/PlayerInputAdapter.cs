using MC.Core.Events;
using MC.Core.Unity.Inputs.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace MC.Game.Inputs
{
    public class PlayerInputAdapter : MonoBehaviour
    {
        private IEventBus _eventBus;

        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Move(InputAction.CallbackContext ctx)
            => _eventBus.Publish(new MoveInputEvent() { Value = ctx.ReadValue<Vector2>() });

        public void Jump() => _eventBus.Publish(new JumpInputEvent() { });

        public void Action(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
                _eventBus.Publish(new ActionInputEvent() { });
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
