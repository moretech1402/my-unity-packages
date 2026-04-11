using System.Collections.Generic;
using MC.Core.Stats.Sources;

namespace MC.Core.Stats
{
    public interface IStatEntryDefinition
    {
        StatId Id { get; }
        IStatSourceDefinition Source { get; }
        float Value { get; }
    }
    
    public interface IStatContainerDefinition
    {
        IReadOnlyList<IStatEntryDefinition> Stats { get; }
    }
}