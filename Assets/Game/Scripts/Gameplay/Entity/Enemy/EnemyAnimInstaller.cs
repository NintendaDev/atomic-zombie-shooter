using Atomic.Entities;
using Game.Gameplay.Entity.Common;
using UnityEngine;

namespace Game.Gameplay.Entity.Enemy
{
    public sealed class EnemyAnimInstaller : SceneEntityInstaller
    {
        [SerializeField] private AnimationInstaller _animationInstaller;

        public override void Install(IEntity entity)
        {
            _animationInstaller.Install(entity);
        }
    }
}