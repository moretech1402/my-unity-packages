using System;
using MC.Core.Stats.Modifiers;
using UnityEngine;

namespace MC.Game.Stats.Modifiers
{
    [Serializable]
    public class StatDeltaModifierEntryData : StatModifierEntryData
    {
        [SerializeField] private float _delta;
        
        public float Delta => _delta;
        
        public override IStatModifier DefaultModifierCreate()
        {
            return new CurrentValueDeltaModifier(_delta);
        }
    }
}