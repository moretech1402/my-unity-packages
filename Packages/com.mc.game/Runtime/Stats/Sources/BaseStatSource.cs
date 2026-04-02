namespace MC.Core.Stats.Sources
{
    public class BaseStatSource : IStatSource
    {
        public float Value { get; set; }

        public BaseStatSource(float value)
        {
            Value = value;
        }

        public float GetValue(IStatsHandler stats)
        {
            return Value;
        }
    }
}