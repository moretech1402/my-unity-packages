namespace MC.Core.Stats.Sources
{
    public class BaseStatSource : IStatSource
    {
        private readonly float _value;

        public BaseStatSource(float value)
        {
            _value = value;
        }

        public float GetValue(IStatsHandler stats)
        {
            return _value;
        }
    }
}