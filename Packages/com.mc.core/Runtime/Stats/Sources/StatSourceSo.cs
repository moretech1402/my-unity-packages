using UnityEngine;

namespace MC.Core.Stats.Sources
{
    [CreateAssetMenu(fileName = "Stat Source", menuName = "Core/Stats/Sources/Create new Stat Source", order = 0)]
    public abstract class StatSourceSo : ScriptableObject
    {
        public abstract IStatSource Create();
    }
}