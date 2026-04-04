using MC.Core.Stats;
using MC.Core.Stats.Sources;
using MC.Game.Stats.Sources;
using UnityEngine;

namespace Features.Game.Stats.Sources
{
    [CreateAssetMenu(
        fileName = "Same Value Stat Source",
        menuName = "Game/Stats/Sources/Create new Same Value Stat Source", order = 0)
    ]
    public class SameValueStatSourceSo : StatSourceSo
    {
        [SerializeField] private StatDefinitionSo _reference;

        public override IStatSource DefaultCreate()
        {
            return new SameValueStatSource(_reference.Id);
        }
    }
}