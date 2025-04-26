using Atomic.Elements;
using Atomic.Entities;
using Modules.Audio;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class TakeDamageSoundBehaviour : IEntityInit, IEntityDispose
    {
        private readonly UniqueAudioRandomizer _uniqueAudioRandomizer;
        private IReactive<TakeDamageArgs> _damageEvent;
        private AudioSource _audioSource;
        private readonly float _volumeScale = 1f;

        public TakeDamageSoundBehaviour(AudioClip[] audioClips)
        {
            _uniqueAudioRandomizer = new UniqueAudioRandomizer(audioClips);
        }

        public TakeDamageSoundBehaviour(AudioClip[] audioClips, float volumeScale) : this(audioClips)
        {
            _volumeScale = volumeScale;
        }

        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _damageEvent = entity.GetTakeDamageEvent();
            _damageEvent.Subscribe(OnTakeDamage);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(TakeDamageArgs _) => 
            _audioSource.PlayOneShot(_uniqueAudioRandomizer.GetRandom(), _volumeScale);
    }
}