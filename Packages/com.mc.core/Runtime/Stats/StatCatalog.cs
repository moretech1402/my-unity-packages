using System.Collections.Generic;
using System.Linq;

namespace MC.Core.Stats
{
    public class StatCatalog : IStatCatalog
    {
        private readonly Dictionary<StatId, IStatDefinition> _definitions;

        public StatCatalog(IEnumerable<IStatDefinition> definitions)
        {
            _definitions = definitions.ToDictionary(d => d.Id);
        }

        public IEnumerable<IStatDefinition> GetAll()
        {
            return _definitions.Values;
        }

        public IStatDefinition Get(StatId id)
        {
            return _definitions[id];
        }
    }
}