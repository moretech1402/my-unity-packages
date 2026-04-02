using MC.Core.Stats.Modifiers;
using MC.Core.Values.Modifiers;

namespace MC.Game.Stats.Modifiers
{
    public class CurrentValueDeltaModifier : IStatModifier
    {
        public IValueModifier ValueModifier;

        public CurrentValueDeltaModifier(float delta)
        {
            ValueModifier = new SumValueModifier(delta);
        }

        public float Apply(float baseValue)
        {
            return ValueModifier.Modify(baseValue);
        }
    }
}
