using UnityEngine;

namespace MC.Core.Unity.Movement
{
    [CreateAssetMenu(fileName = "TopDown2DMoveDirectionStrategy", menuName = "Core/Movement/TopDown2DMoveDirectionStrategy")]
    public class TopDown2DMoveDirectionStrategy : MoveDirectionStrategySo
    {
        public override Vector3 GetDirection(Vector2 input, Camera camera)
        {
            return (Vector3)input;
        }
    }
}