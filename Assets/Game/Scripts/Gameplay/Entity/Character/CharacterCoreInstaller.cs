using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Entity.Common;
using Game.Gameplay.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Character
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField, Required] private Rigidbody _rigidbody;
        [SerializeField, Required] private Transform _transform;
        [SerializeField, Required] private WeaponEntity _startWeapon;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField] private RigidbodyMoveInstaller _moveInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private Transform[] _deathHideObjects;

        public override void Install(IEntity entity)
        {
            entity.AddPlayerTag();
            entity.AddRigidbody(_rigidbody);
            entity.AddTransform(_transform);
            
            _moveInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _healthInstaller.Install(entity);
            InstallWeapon(entity);
            
            entity.AddBehaviour(new DeathObjectDisableBehaviour(_deathHideObjects));
        }

        private void InstallWeapon(IEntity entity)
        {
            entity.AddCurrentWeapon(new ReactiveVariable<IWeaponEntity>(_startWeapon));
            
            entity.AddAttackCondition(new AndExpression(() => entity.IsAlive(),
                () => entity.IsExistsWeapon(out IWeaponEntity weapon) && weapon.GetAttackCondition().Invoke()));
            
            entity.AddAttackEvent(new BaseEvent());
            
            entity.AddAttackAction(new BaseAction(() =>
            {
                if (entity.GetAttackCondition().Invoke() == false)
                    return;
                
                IEntity weapon = entity.GetCurrentWeapon().Value;
                weapon.GetAttackAction().Invoke();
                entity.GetAttackEvent().Invoke();
            }));
        }
    }
}