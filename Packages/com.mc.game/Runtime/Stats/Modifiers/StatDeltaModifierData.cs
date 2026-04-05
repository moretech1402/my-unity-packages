using System;
using MC.Core.Stats;
using MC.Core.Stats.Modifiers;
using UnityEngine;

namespace MC.Game.Stats.Modifiers
{
    [Serializable]
    public class StatDeltaModifierData : StatModifierData
    {
        [SerializeField] private StatDefinitionSo _stat;
        [SerializeField] private float _delta;
        
        public StatDefinitionSo Stat => _stat;
        public float Delta => _delta;
        
        public override IStatModifier DefaultCreate()
        {
            return new CurrentValueDeltaModifier(_delta);
        }
    }
}