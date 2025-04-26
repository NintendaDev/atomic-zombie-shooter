using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Entity;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    [Serializable]
    public sealed class HealthInstaller : IEntityInstaller
    {
        [SerializeField, MinValue(0)] private int _maxValue = 100;
        
        public void Install(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.AddHealth(new Health(_maxValue, _maxValue));
            entity.AddTakeDamageEvent(new BaseEvent<TakeDamageArgs>());
            entity.AddDeathEvent(new ReactiveVariable<TakeDamageArgs>());
            entity.AddHealEvent(new ReactiveInt());
        }
    }
}