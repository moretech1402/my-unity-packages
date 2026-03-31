using UnityEngine;

namespace Game.Movement
{
    public interface IMove
    {
        public void Move(Vector3 movement);
    }

    // TODO: Extract the logic of moving in the Update of childs
    public abstract class MovementController3D : MonoBehaviour, IMove
    {
        [SerializeField] protected CharacterController controller;

        [SerializeField] protected float moveSpeed = 5f;

        protected Vector3 Velocity = new();

        private void Awake()
        {
            if (controller != null) return;
            Debug.LogError($"{name} requires a CharacterController component.");
            enabled = false;
        }

        public abstract void Move(Vector3 movement);

        protected void DoMove() => controller.Move(Velocity * Time.deltaTime);
    }

}
