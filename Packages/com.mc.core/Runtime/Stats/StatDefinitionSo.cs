using MC.Core.Stats.Sources;
using UnityEngine;

namespace MC.Core.Stats
{
    [CreateAssetMenu(fileName = "Stat Definition", menuName = "Core/Stats/Create new Stat", order = 0)]
    public class StatDefinitionSo : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private StatSourceSo _source;
        
        public StatSourceSo Source => _source;
        
        public StatId Id => new StatId(_id);

        public Stat Create()
        {
            return new Stat(_source.DefaultCreate());
        }
    }
}