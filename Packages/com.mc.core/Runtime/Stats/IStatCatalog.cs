using System.Collections.Generic;

namespace MC.Core.Stats
{
    public interface IStatCatalog
    {
        IEnumerable<IStatDefinition> GetAll();

        IStatDefinition Get(StatId id);
    }
}