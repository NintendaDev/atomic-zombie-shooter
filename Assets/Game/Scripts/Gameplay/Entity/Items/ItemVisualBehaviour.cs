using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Items
{
    public sealed class ItemVisualBehaviour : IEntityInit, IEntityDispose
    {
        private readonly GameObject _visual;
        private readonly ParticleSystem _takeEffect;
        private readonly AudioClip _takeSound;
        private IEvent _takeEvent;
        private AudioSource _audioSource;

        public ItemVisualBehaviour(GameObject visual, ParticleSystem takeEffect, AudioClip takeSound)
        {
            _visual = visual;
            _takeEffect = takeEffect;
            _takeSound = takeSound;
        }

        public void Init(in IEntity entity)
        {
            _takeEvent = entity.GetItemTakeEvent();
            _audioSource = entity.GetAudioSource();
            _takeEvent.Subscribe(OnTake);
        }

        public void Dispose(in IEntity entity)
        {
            _takeEvent.Unsubscribe(OnTake);
        }

        private void OnTake()
        {
            _takeEffect.Play();
            _audioSource.PlayOneShot(_takeSound);
            _visual.SetActive(false);
        }
    }
}