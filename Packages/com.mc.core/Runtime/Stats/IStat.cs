using System.Collections.Generic;
using MC.Core.Stats.Modifiers;
using MC.Core.Stats.Sources;

namespace MC.Core.Stats
{
    public interface IStat
    {

    }

    public class StatId
    {
        public string Value { get; }

        public StatId(string id)
        {
            Value = id;
        }
    }

    public class Stat : IStat
    {
        public IStatSource Source { get; }
        public List<IStatModifier> Modifiers { get; set; }

        public Stat(IStatSource source)
        {
            Source = source;
            Modifiers = new List<IStatModifier>();
        }

        internal void AddModifier(IStatModifier modifier) => Modifiers.Add(modifier);

        internal void RemoveModifier(IStatModifier modifier) => Modifiers.Remove(modifier);

    }
}
