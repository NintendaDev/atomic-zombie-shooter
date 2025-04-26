using System;
using Atomic.Entities;
using Game.Animation;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    [Serializable]
    public sealed class AnimationInstaller : IEntityInstaller
    {
        [SerializeField, Required]
        private Animator _animator;

        [SerializeField, Required]
        private AnimationEventReceiver _animationReceiver;
        
        public void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddAnimationEventReceiver(_animationReceiver);
            entity.AddBehaviour(new MoveAnimationBehaviour(AnimatorParameters.IsMovingFlagName));
            entity.AddBehaviour(new DieAnimationBehaviour(AnimatorParameters.DeathTriggerName));
            entity.AddBehaviour(new AttackAnimationBehaviour(AnimatorParameters.AttackTriggerName));
            entity.AddBehaviour(new TakeDamageAnimationBehaviour(AnimatorParameters.TakeDamageTriggerName));
        }
    }
}