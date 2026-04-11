using System;
using MC.Core.Stats;
using MC.Core.Stats.Modifiers;
using UnityEngine;

namespace MC.Game.Stats.Modifiers
{
    [Serializable]
    public abstract class StatModifierEntryData : IStatModifierEntryDefinition
    {
        [SerializeField] private StatDefinitionSo _stat;
        
        public StatId StatId => _stat.Id;
        
        public abstract IStatModifier DefaultModifierCreate();
    }
}