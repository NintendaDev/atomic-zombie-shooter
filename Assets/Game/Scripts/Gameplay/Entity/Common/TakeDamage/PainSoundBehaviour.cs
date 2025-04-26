using System;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using Modules.Randomize;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class PainSoundBehaviour : IEntityInit, IEntityDispose
    {
        private IReactive<TakeDamageArgs> _damageEvent;
        private Health _health;
        private AudioSource _audioSource;
        
        private readonly Level[] _damageLevels;
        private readonly float _volumeScale = 1f;

        public PainSoundBehaviour(Level[] damageLevels)
        {
            _damageLevels = damageLevels;
        }
        
        public PainSoundBehaviour(Level[] damageLevels, float volumeScale)
        {
            _damageLevels = damageLevels;
            _volumeScale = volumeScale;
        }
        
        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _audioSource = entity.GetAudioSource();
            _damageEvent = entity.GetTakeDamageEvent();
            _damageEvent.Subscribe(OnDamageTaken);
        }
        
        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageTaken);
        }
        
        private void OnDamageTaken(TakeDamageArgs _)
        {
            PlaySound(_health.GetPercent());
        }
        
        private void PlaySound(float healthPercent)
        {
            for (int i = _damageLevels.Length - 1; i >= 0; i--)
            {
                Level level = _damageLevels[i];
                
                if (level.Percent >= healthPercent)
                {
                    if (level.TryGetRandomClip(out AudioClip clip) == false)
                    {
                        Debug.Log("No found pain audio clip");

                        return;
                    }
                    
                    _audioSource.PlayOneShot(clip, _volumeScale);
                    
                    return;
                }
            }
        }

        [Serializable]
        public struct Level
        {
            [SerializeField, Range(0.01f, 1.0f)]
            public float Percent;

            [SerializeField]
            public AudioClip[] Clips;

            public bool TryGetRandomClip(out AudioClip clip) => Clips.TryGetRandom(out clip);
        }
    }
}