using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public abstract class MoveInstaller : IEntityInstaller
    {
        [SerializeField] private LayerMask _groundLayerMask = ~0;
        [SerializeField, MinValue(0)] private float _moveSpeed;
        
        public virtual void Install(IEntity entity)
        {
            entity.AddMovableTag();
            entity.AddGroundLayerMask(_groundLayerMask);
            entity.AddMoveDirection(new ReactiveVector3());
            entity.AddMoveCondition(new AndExpression(entity.IsAlive));
            entity.AddMoveSpeed(new ReactiveFloat(_moveSpeed));
        }
    }
}