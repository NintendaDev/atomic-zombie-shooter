using System;
using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    [Serializable]
    public sealed class RotationInstaller : IEntityInstaller
    {
        [SerializeField, MinValue(0)] private float _angularSpeed;
        
        public void Install(IEntity entity)
        {
            entity.AddAngularSpeed(new Const<float>(_angularSpeed));
            entity.AddRotateCondition(new AndExpression(entity.IsAlive));
            entity.AddRotateDirection(new ReactiveVector3());
            entity.AddBehaviour<RotationBehaviour>();
        }
    }
}