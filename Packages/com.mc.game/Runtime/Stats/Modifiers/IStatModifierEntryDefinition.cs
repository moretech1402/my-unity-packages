using MC.Core.Stats;
using MC.Core.Stats.Modifiers;

namespace MC.Game.Stats.Modifiers
{
    public interface IStatModifierEntryDefinition
    {
        StatId StatId { get; }
        IStatModifier DefaultModifierCreate();
    }
}