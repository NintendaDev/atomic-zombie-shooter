using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Entity.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Enemy
{
    public sealed class EnemyVfxInstaller : SceneEntityInstaller
    {
        [SerializeField, Required]
        private ParticleSystem _bulletBlood;
        
        [SerializeField, Required]
        private ParticleSystem _meleeBlood;

        [SerializeField, Required, AssetsOnly]
        private SceneEntity _deadBlood;

        [SerializeField, Required]
        private Transform _rootTransform;

        public override void Install(IEntity entity)
        {
            GameContext gameContext = GameContext.Instance;
            entity.AddBehaviour(new BodyFallBloodBehaviour(gameContext, _deadBlood, _rootTransform));
            entity.AddBehaviour(new TakeDamageBloodBehaviour(_bulletBlood, _meleeBlood, _rootTransform));
        }
    }
}