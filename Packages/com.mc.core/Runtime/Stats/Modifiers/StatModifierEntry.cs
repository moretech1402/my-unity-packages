namespace MC.Core.Stats.Modifiers
{
    public class StatModifierEntry
    {
        public StatId StatId { get; }
        public IStatModifier Modifier { get; }

        public StatModifierEntry(StatId statId, IStatModifier modifier)
        {
            StatId = statId;
            Modifier = modifier;
        }
    }
}