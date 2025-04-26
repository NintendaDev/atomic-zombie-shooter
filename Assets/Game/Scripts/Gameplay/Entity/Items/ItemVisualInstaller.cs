using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Items
{
    public sealed class ItemVisualInstaller : SceneEntityInstaller
    {
        [SerializeField, Required]
        private ParticleSystem _takeEffect;
        
        [SerializeField, Required]
        private GameObject _visual;

        [SerializeField, Required]
        private AudioClip _takeSound;

        [SerializeField, Required]
        private AudioSource _audioSource;
        
        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            entity.AddBehaviour(new ItemVisualBehaviour(_visual, _takeEffect, _takeSound));
        }
    }
}