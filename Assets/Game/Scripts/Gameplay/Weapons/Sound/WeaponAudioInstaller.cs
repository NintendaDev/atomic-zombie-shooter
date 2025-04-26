using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Weapons
{
    public sealed class WeaponAudioInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField, Required] private AudioClip[] _attackAudioClips;

        protected override void Install(IWeaponEntity entity)
        {
            entity.AddAttackSounds(_attackAudioClips);
        }
    }
}