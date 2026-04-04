using UnityEngine;

namespace MC.Core.Stats.Sources
{
    public abstract class StatSourceSo : ScriptableObject
    {
        public abstract IStatSource DefaultCreate();
    }
}