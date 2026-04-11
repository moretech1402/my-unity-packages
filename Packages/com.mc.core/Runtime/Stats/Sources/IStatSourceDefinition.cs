namespace MC.Core.Stats.Sources
{
    public interface IStatSourceDefinition
    {
        IStatSource DefaultCreate();
    }
}