using System.Collections.Generic;

namespace MC.Core.Stats
{
    public interface IStatCatalog
    {
        IEnumerable<StatDefinitionSo> GetAll();

        StatDefinitionSo Get(StatId id);
    }
}