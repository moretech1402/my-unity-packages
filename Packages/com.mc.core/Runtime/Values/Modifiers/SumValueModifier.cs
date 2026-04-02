namespace MC.Core.Values.Modifiers
{
    public class SumValueModifier : IValueModifier
    {
        public float Value { get; }

        public SumValueModifier(float value)
        {
            Value = value;
        }

        public float Modify(float baseValue) => baseValue + Value;
    }
}
