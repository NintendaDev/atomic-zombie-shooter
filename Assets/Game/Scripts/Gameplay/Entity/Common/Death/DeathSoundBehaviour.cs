using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class DeathSoundBehaviour : IEntityInit, IEntityDispose
    {
        private AudioSource _audioSource;
        private IReactive<TakeDamageArgs> _dieEvent;
        private readonly AudioClip[] _audioClips;

        public DeathSoundBehaviour(AudioClip[] audioClips)
        {
            _audioClips = audioClips;
        }

        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            _dieEvent = entity.GetDeathEvent();

            _dieEvent.Subscribe(OnDie);
        }

        public void Dispose(in IEntity entity)
        {
            _dieEvent.Unsubscribe(OnDie);
        }

        private void OnDie(TakeDamageArgs _) => _audioSource.TryPlayRandomSound(_audioClips);
    }
}