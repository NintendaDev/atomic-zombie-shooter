using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class TargetFollowBehaviour : IEntityInit, IEntityUpdate
    {
        private IReactiveVariable<Transform> _target;
        private IEntity _follower;

        public void Init(in IEntity entity)
        {
            _follower = entity;
            _target = _follower.GetTarget();
        }
        
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _follower.Follow(_target.Value);
        }
    }
}