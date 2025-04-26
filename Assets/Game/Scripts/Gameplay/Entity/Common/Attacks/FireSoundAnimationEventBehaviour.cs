using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Weapons;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class FireSoundAnimationEventBehaviour : IEntityInit, IEntityDispose
    {
        private readonly string _fireAnimationEventName;
        private IReactiveVariable<IWeaponEntity> _currentWeapon;
        private AudioClip[] _attackSounds;
        private AnimationEventReceiver _animationReceiver;
        private AudioSource _audioSource;

        public FireSoundAnimationEventBehaviour(string fireAnimationEventName)
        {
            _fireAnimationEventName = fireAnimationEventName;
        }

        public void Init(in IEntity entity)
        {
            _currentWeapon = entity.GetCurrentWeapon();
            
            if (_currentWeapon.Value != null)
                OnWeaponChange(_currentWeapon.Value);
            
            _animationReceiver = entity.GetAnimationEventReceiver();
            _audioSource = entity.GetAudioSource();
            _animationReceiver.EventReceived += OnAnimationEvent;
            
            _currentWeapon.Subscribe(OnWeaponChange);
        }

        public void Dispose(in IEntity entity)
        {
            _animationReceiver.EventReceived -= OnAnimationEvent;
            _currentWeapon.Unsubscribe(OnWeaponChange);
        }

        private void OnAnimationEvent(string animationEventName)
        {
            if (_fireAnimationEventName != animationEventName)
                return;

            AudioUseCases.TryPlayRandomSound(_audioSource, _attackSounds, minPitch: 0.9f, maxPitch: 1.1f);
        }

        private void OnWeaponChange(IWeaponEntity nextWeapon)
        {
           _attackSounds = nextWeapon.GetAttackSounds();
        }
    }
}