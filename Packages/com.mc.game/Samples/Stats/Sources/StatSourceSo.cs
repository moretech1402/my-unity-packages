using UnityEngine;

namespace MC.Core.Stats.Sources
{
    public abstract class StatSourceSo : ScriptableObject, IStatSourceDefinition
    {
        public abstract IStatSource DefaultCreate();
    }
}