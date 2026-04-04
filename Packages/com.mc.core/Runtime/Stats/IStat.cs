using System;
using System.Collections.Generic;
using MC.Core.Stats.Modifiers;
using MC.Core.Stats.Sources;

namespace MC.Core.Stats
{
    public interface IStat
    {

    }

    public sealed class StatId : IEquatable<StatId>
    {
        private readonly string _value;

        public StatId(string id)
        {
            _value = id ?? throw new ArgumentNullException(nameof(id));
        }

        public bool Equals(StatId other)
        {
            if (other is null)
                return false;

            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            return obj is StatId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
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

        public void AddModifier(IStatModifier modifier) => Modifiers.Add(modifier);

        public void RemoveModifier(IStatModifier modifier) => Modifiers.Remove(modifier);

    }
}