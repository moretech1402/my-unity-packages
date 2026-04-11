using MC.Core.Stats.Sources;
using UnityEngine;

namespace MC.Game.Stats.Sources
{
    [CreateAssetMenu(
        fileName = "Base Stat Source",
        menuName = "Game/Stats/Sources/Create new Base Stat Source", order = 0)
    ]
    public class BaseStatSourceSo : StatSourceSo
    {
        [SerializeField] private float _defaultValue;
        
        public override IStatSource DefaultCreate()
        {
            return new BaseStatSource(_defaultValue);
        }
    }
    
}

