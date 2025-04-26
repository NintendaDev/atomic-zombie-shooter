using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class TakeDamageVfxUseCase
    {
        public static void PlayProjectileDamageEffect(this IEntity source, Transform originTransform, 
            ParticleSystem effect)
        {
            if (source == null)
                return;
            
            Vector3 sourcePosition = source.GetTransform().position;
            Vector3 myPosition = originTransform.position;
            Vector3 direction = (sourcePosition - myPosition).normalized;
            
            direction.y = 0;
            
            effect.transform.forward = direction;
            effect.Play(withChildren: true);
        }
    }
}