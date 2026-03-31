using MC.Core.Unity.Movement;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace MC.Game.Movement
{
    public class GameMovementLifetimeScope : LifetimeScope
    {
        [SerializeField] private PlayerMovementAI playerMovementPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(playerMovementPrefab, Lifetime.Transient);
        }
    }
    
}
