using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.Movement
{
    public class GroundNavigator3D : MovementController3D
    {
        public enum FacingMode { None, MovementDirection, Target }

        // TODO: Extract stats to another component
        [FormerlySerializedAs("_defaultRunMult")]
        [Header("Stats")]
        [SerializeField] private float defaultRunMult = 2;
        [SerializeField] private float defaultJumpForce = 5f;
        [SerializeField] private float slideSpeed = 7, slideDownSpeed = 10;

        [Header("Navigation")]
        [SerializeField] private float destinationThreshold = 0.15f;

        [Header("Facing")]
        [SerializeField] private FacingMode facingMode = FacingMode.MovementDirection;

        [FormerlySerializedAs("_onMoved")]
        [Header("Events")]
        [SerializeField] private UnityEvent<Vector3, bool> onMoved;
        [SerializeField] private UnityEvent onStopped;
        [SerializeField] private UnityEvent onJumped;
        [SerializeField] private UnityEvent<bool> onGrounded;
        [SerializeField] private UnityEvent<Vector3> onDestinationReached;

        public bool IsActive { get; set; } = true;
        public bool IsNavigating => _destination.HasValue;

        private bool _isRunning, _lastIsGrounded = true;
        private Vector3 _currentMovementInput, _hitNormal, _normalizedMovement;

        private Vector3? _destination;
        private float _activeDestinationThreshold;
        private Action _onDestinationReached;

        private Transform _facingTarget;
        private Vector3? _facingPoint;

        private const float GravityValue = -9.81f;

        private bool IsGrounded => controller.isGrounded;
        private bool CanDoGroundActions => IsActive && IsGrounded;

        private void OnControllerColliderHit(ControllerColliderHit hit) => _hitNormal = hit.normal;

        private void Update()
        {
            if (!IsActive) return;

            if (_destination.HasValue) UpdateNavigation();

            CalculateAndApplyHorizontalMovement();
            ApplyFacing();

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
        
        public void MoveTo(Transform target) => MoveTo(target.position);

        /// <summary>
        /// Mueve al agente hacia una coordenada del mundo. Ignora la altura (eje Y) al calcular
        /// la distancia, ya que la gestiona el CharacterController/gravedad.
        /// </summary>
        /// <param name="destination">Coordenada de destino en espacio de mundo.</param>
        /// <param name="onReached">Callback opcional invocado una vez al llegar al destino.</param>
        /// <param name="stoppingDistance">Distancia a la que se considera alcanzado el destino. Si es null, usa destinationThreshold.</param>
        public void MoveTo(Vector3 destination, Action onReached = null, float? stoppingDistance = null)
        {
            _destination = destination;
            _onDestinationReached = onReached;
            _activeDestinationThreshold = stoppingDistance ?? destinationThreshold;
        }

        public void StopNavigating()
        {
            _destination = null;
            _onDestinationReached = null;
            Move(Vector3.zero);
        }

        /// <summary>Hace que el agente mire de forma continua hacia un Transform.</summary>
        public void LookAt(Transform target)
        {
            facingMode = FacingMode.Target;
            _facingTarget = target;
            _facingPoint = null;
        }

        /// <summary>Hace que el agente mire de forma continua hacia un punto fijo.</summary>
        public void LookAt(Vector3 point)
        {
            facingMode = FacingMode.Target;
            _facingTarget = null;
            _facingPoint = point;
        }

        /// <summary>Vuelve al comportamiento por defecto: mirar hacia la dirección de movimiento.</summary>
        public void FaceMovementDirection()
        {
            facingMode = FacingMode.MovementDirection;
            _facingTarget = null;
            _facingPoint = null;
        }

        public void StopFacing() => facingMode = FacingMode.None;

        private void UpdateNavigation()
        {
            if (_destination == null) return;
            var destination = _destination.Value;
            var toDestination = destination - transform.position;
            toDestination.y = 0;
            var distance = toDestination.magnitude;

            if (distance <= _activeDestinationThreshold)
            {
                CompleteNavigation(destination);
                return;
            }

            Move(toDestination.normalized);
        }

        private void CompleteNavigation(Vector3 reachedPosition)
        {
            _destination = null;
            Move(Vector3.zero);

            var callback = _onDestinationReached;
            _onDestinationReached = null;
            callback?.Invoke();

            onDestinationReached?.Invoke(reachedPosition);
        }

        private void CalculateAndApplyHorizontalMovement()
        {
            if (!(IsActive || IsGrounded)) return;

            // Calculate Speed
            var speed = Velocity == Vector3.zero ? 0 : moveSpeed;
            var runMult = _isRunning ? defaultRunMult : 1;

            // To Avoid speed increase when diagonal move
            _normalizedMovement = Vector3.ClampMagnitude(_currentMovementInput, 1);

            var finalMove = speed * runMult * _normalizedMovement;
            Velocity = new Vector3(finalMove.x, Velocity.y, finalMove.z);

            if (finalMove.magnitude > 0) onMoved?.Invoke(finalMove, _isRunning);
            else onStopped?.Invoke();
        }

        private void ApplyFacing()
        {
            switch (facingMode)
            {
                case FacingMode.MovementDirection:
                    if (_normalizedMovement.sqrMagnitude > 0.0001f)
                        transform.LookAt(transform.position + _normalizedMovement);
                    break;

                case FacingMode.Target:
                    if (!TryGetFacingPoint(out var point)) break;
                    point.y = transform.position.y;
                    if ((point - transform.position).sqrMagnitude > 0.0001f)
                        transform.LookAt(point);
                    break;

                case FacingMode.None:
                default:
                    break;
            }
        }

        private bool TryGetFacingPoint(out Vector3 point)
        {
            if (_facingTarget)
            {
                point = _facingTarget.position;
                return true;
            }

            if (_facingPoint.HasValue)
            {
                point = _facingPoint.Value;
                return true;
            }

            point = default;
            return false;
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