using Atomic.Entities;
using Game.Animation;
using Game.Gameplay.Entity.Common;
using Modules.Audio;
using UnityEngine;

namespace Game.Gameplay.Entity.Character
{
    public sealed class CharacterAudioInstaller : SceneEntityInstaller
    {
        private const float PainVolumeScale = 3f;
        
        [SerializeField]
        private AudioSource _audioSource;
        
        [SerializeField]
        private PainSoundBehaviour.Level[] _painLevels;

        [SerializeField]
        private AudioClip[] _deathClips;

        [SerializeField]
        private AudioClip[] _moveStepClips;

        [SerializeField]
        private AudioClip _bodyFallClip;

        [SerializeField]
        private AudioClip _meleeDamageClip;

        [SerializeField]
        private AudioClip _bulletDamageClip;
        
        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            entity.AddBehaviour(new DeathSoundBehaviour(_deathClips));
            
            entity.AddBehaviour(new MoveStepSoundAnimationEventBehaviour(new UniqueAudioRandomizer(_moveStepClips),
                AnimatorParameters.MoveStepEventName));
            
            entity.AddBehaviour(new PainSoundBehaviour(_painLevels, PainVolumeScale));
            
            entity.AddBehaviour(new BodyFallSoundAnimationEventBehaviour(_bodyFallClip, 
                AnimatorParameters.BodyFallEventName));
            
            entity.AddBehaviour(new FireSoundAnimationEventBehaviour(AnimatorParameters.FireEventName));
        }
    }
}