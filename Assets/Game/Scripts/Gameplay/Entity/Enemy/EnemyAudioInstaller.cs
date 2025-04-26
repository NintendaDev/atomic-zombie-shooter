using Atomic.Entities;
using Game.Animation;
using Game.Gameplay.Entity.Common;
using Modules.Audio;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Enemy
{
    public sealed class EnemyAudioInstaller : SceneEntityInstaller
    {
        private const float TakeDamageVolumeScale = 3f;
        
        [SerializeField, Required]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip[] _deathClips;

        [SerializeField]
        private AudioClip[] _attackClips;

        [SerializeField]
        private AudioClip[] _damageClips;

        [SerializeField, Required]
        private AudioClip _bodyFallClip;

        [SerializeField, Required]
        private AudioClip _meleeDamageClip;

        [SerializeField, Required]
        private AudioClip _bulletDamageClip;
        
        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            entity.AddBehaviour(new DeathSoundBehaviour(_deathClips));
            
            entity.AddBehaviour(new BodyFallSoundAnimationEventBehaviour(_bodyFallClip, 
                AnimatorParameters.BodyFallEventName));
            
            entity.AddBehaviour(new AttackSoundAnimationEventBehaviour(new UniqueAudioRandomizer(_bodyFallClip),
                AnimatorParameters.StartAttackEventName));
            
            entity.AddBehaviour(new TakeDamageSoundBehaviour(_damageClips, TakeDamageVolumeScale));
        }
    }
}