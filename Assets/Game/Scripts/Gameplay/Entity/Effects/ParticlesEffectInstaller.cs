using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Effects
{
    public sealed class ParticlesEffectInstaller : SceneEntityInstaller
    {
        [SerializeField, Required] private ParticleSystem _particleSystem;
        
        public override void Install(IEntity entity)
        {
            entity.AddVisualEffectTag();
            entity.AddTransform(transform);
            entity.AddStartVisualEffectAction(new BaseAction(() => _particleSystem.Play(withChildren: true)));
            
            entity.AddStopVisualEffectAction(new BaseAction(() =>
            {
                _particleSystem.Stop();
                _particleSystem.Clear();
            }));
        }
    }
}