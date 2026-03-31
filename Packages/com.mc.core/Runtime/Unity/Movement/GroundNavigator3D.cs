using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.Movement
{
    public class GroundNavigator3D : MovementController3D
    {
        // TODO: Extract stats to another component
        [FormerlySerializedAs("_defaultRunMult")]
        [Header("Stats")]
        [SerializeField] private float defaultRunMult = 2;
        [SerializeField] private float defaultJumpForce = 5f;
        [SerializeField] private float slideSpeed = 7, slideDownSpeed = 10;

        [FormerlySerializedAs("_onMoved")]
        [Header("Events")]

        [SerializeField] private UnityEvent<Vector3, bool> onMoved;
        [SerializeField] private UnityEvent onStopped;
        [SerializeField] private UnityEvent onJumped;
        [SerializeField] private UnityEvent<bool> onGrounded;

        public bool IsActive { get; set; } = true;

        private bool _isRunning, _lastIsGrounded = true;
        private Vector3 _currentMovementInput, _hitNormal;

        private const float GravityValue = -9.81f;

        private bool IsGrounded => controller.isGrounded;
        private bool CanDoGroundActions => IsActive && IsGrounded;

        private void OnControllerColliderHit(ControllerColliderHit hit) => _hitNormal = hit.normal;

        private void Update()
        {
            if (!IsActive) return;

            CalculateAndApplyHorizontalMovement();

            // --- Vertical Velocity Modifiers ---
            HandleGravity();
            SlopeDown();

            DoMove();
        }

        public void Jump()
        {
            if (!CanDoGroundActions) return;
            Velocity.y = defaultJumpForce;
            onJumped?.Invoke();
        }

        public void Run(bool running)
        {
            _isRunning = running;
        }

        public override void Move(Vector3 movement)
        {
            if (CanDoGroundActions)
                _currentMovementInput = movement;
        }

        private void CalculateAndApplyHorizontalMovement()
        {
            if (!(IsActive || IsGrounded)) return;

            // Calculate Speed
            var speed = Velocity == Vector3.zero ? 0 : moveSpeed;
            var runMult = _isRunning ? defaultRunMult : 1;

            // To Avoid speed increase when diagonal move
            var normalizedMovement = Vector3.ClampMagnitude(_currentMovementInput, 1);

            var finalMove = speed * runMult * normalizedMovement;
            Velocity = new(finalMove.x, Velocity.y, finalMove.z);

            if (finalMove.magnitude > 0)
            {
                transform.LookAt(transform.position + normalizedMovement);
                onMoved?.Invoke(finalMove, _isRunning);
            }
            else onStopped?.Invoke();
        }

        private void HandleGravity()
        {
            if (!IsActive) return;

            var yAceleration = GravityValue * Time.deltaTime;
            Velocity.y += yAceleration;

            var isGrounded = IsGrounded;
            if (isGrounded && Velocity.y < 0) Velocity.y = -1;

            if (_lastIsGrounded == isGrounded) return;
            _lastIsGrounded = isGrounded;
            onGrounded?.Invoke(isGrounded);
        }

        private void SlopeDown()
        {
            if (!IsActive) return;

            var isOnSlope = Vector3.Angle(Vector3.up, _hitNormal) >= controller.slopeLimit;
            if (!isOnSlope) return;

            Velocity = new Vector3(
                AddSlideSpeed(Velocity.x, _hitNormal.x),
                Velocity.y - slideDownSpeed,
                AddSlideSpeed(Velocity.z, _hitNormal.z));
            return;

            float AddSlideSpeed(float current, float axis)
            {
                var slopeFactor = 1f - _hitNormal.y;
                return current + slopeFactor * axis * slideSpeed;
            }
        }
    }
}
