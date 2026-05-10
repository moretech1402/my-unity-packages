using MC.Core.Stats.Modifiers.Scopes;

namespace MC.Core.Stats.Modifiers
{
    public interface IStatModifier
    {
        float Apply(float baseValue);
        IScope Scope { get; }
    }
}
