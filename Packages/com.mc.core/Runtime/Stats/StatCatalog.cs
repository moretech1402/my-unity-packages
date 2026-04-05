using System.Collections.Generic;
using System.Linq;

namespace MC.Core.Stats
{
    public class StatCatalog : IStatCatalog
    {
        private readonly Dictionary<StatId, StatDefinitionSo> _definitions;

        public StatCatalog(IEnumerable<StatDefinitionSo> definitions)
        {
            _definitions = definitions.ToDictionary(d => d.Id);
        }

        public IEnumerable<StatDefinitionSo> GetAll()
        {
            return _definitions.Values;
        }

        public StatDefinitionSo Get(StatId id)
        {
            return _definitions[id];
        }
    }
}