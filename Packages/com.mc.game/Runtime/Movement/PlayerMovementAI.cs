using System;
using MC.Core.Events;
using MC.Core.Unity.Inputs;
using MC.Core.Unity.Inputs.Events;
using MC.Core.Unity.Movement;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

namespace MC.Game.Movement
{
    public class PlayerMovementAI : MonoBehaviour
    {
        [SerializeField] private Camera cameraRef;
        [SerializeField] private MoveDirectionStrategySo moveStrategy;
        
        [Header("Events")]
        [SerializeField] private UnityEvent<Vector3> onMove;
        [SerializeField] private UnityEvent<bool> onRun;
        [SerializeField] private UnityEvent onJump;
        [SerializeField] private UnityEvent onAttack;

        private Vector2 _currentMovementInput = Vector2.zero;

        private IEventBus _eventBus;

        // Cache de delegates para evitar allocations
        private Action<MoveInputEvent> _onMoveDelegate;
        private Action<JumpInputEvent> _onJumpDelegate;
        private Action<RunInputEvent> _onRunDelegate;
        private Action<InputActionEvent> _onAttackDelegate;
        
        [Inject]
        public void Construct(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        private void OnEnable()
        {
            _onMoveDelegate = OnMoveInput;
            _onJumpDelegate = Jump;
            _onRunDelegate = Run;
            _onAttackDelegate = Attack;

            _eventBus.Subscribe(_onMoveDelegate);
            _eventBus.Subscribe(_onJumpDelegate);
            _eventBus.Subscribe(_onRunDelegate);
            _eventBus.Subscribe(_onAttackDelegate);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe(_onMoveDelegate);
            _eventBus.Unsubscribe(_onJumpDelegate);
            _eventBus.Unsubscribe(_onRunDelegate);
            _eventBus.Unsubscribe(_onAttackDelegate);
        }

        private void Update()
        {
            if (_currentMovementInput == Vector2.zero)
            {
                onMove?.Invoke(Vector3.zero);
                return;
            }

            onMove?.Invoke(moveStrategy.GetDirection(_currentMovementInput, cameraRef));
        }

        private void OnMoveInput(MoveInputEvent evt) => _currentMovementInput = evt.Value;

        private void Jump(JumpInputEvent evt) => onJump?.Invoke();

        private void Run(RunInputEvent evt) => onRun?.Invoke(evt.IsRunning);

        private void Attack(InputActionEvent evt) => onAttack?.Invoke();
    }
}