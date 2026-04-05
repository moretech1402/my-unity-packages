using System;
using MC.Core.Stats.Modifiers;

namespace MC.Game.Stats.Modifiers
{
    [Serializable]
    public abstract class StatModifierData
    {
        public abstract IStatModifier DefaultCreate();
    }
}