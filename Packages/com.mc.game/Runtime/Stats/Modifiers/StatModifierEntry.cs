using MC.Core.Stats;
using MC.Core.Stats.Modifiers;

namespace MC.Game.Stats.Modifiers
{
    public class StatModifierEntry
    {
        private readonly StatId _statId;
        private readonly IStatModifier _modifier;
        
        public StatModifierEntry(StatId statId, IStatModifier modifier)
        {
            _statId = statId;
            _modifier = modifier;
        }
    }
}