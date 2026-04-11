using MC.Core.Stats.Modifiers;
using MC.Core.Values.Modifiers;

namespace MC.Game.Stats.Modifiers
{
    public class CurrentValueDeltaModifier : IStatModifier
    {
        private readonly IValueModifier _valueModifier;

        public CurrentValueDeltaModifier(float delta)
        {
            _valueModifier = new SumValueModifier(delta);
        }

        public float Apply(float baseValue)
        {
            return _valueModifier.Modify(baseValue);
        }
    }
}
