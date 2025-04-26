using Atomic.Entities;
using Game.Gameplay.Entity.Common;
using UnityEngine;

namespace Game.Gameplay.Weapons
{
    public sealed class WeaponVfxInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private ParticleSystem _shootEffect;

        protected override void Install(IWeaponEntity entity)
        {
            entity.AddBehaviour(new FireVfxBehaviour(_shootEffect));
        }
    }
}