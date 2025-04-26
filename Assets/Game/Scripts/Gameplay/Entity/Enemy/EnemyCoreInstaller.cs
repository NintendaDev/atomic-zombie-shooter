using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.Animation;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Entity.Common;
using Game.Gameplay.Weapons;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Enemy
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField, Required] private Transform _transform;
        [SerializeField, Required] private Rigidbody _rigidbody;
        [SerializeField, Required] private CollisionEventReceiver _collisionEventReceiver;
        [SerializeField] private AnimatorMoveInstaller _moveInstaller;
        [SerializeField] private RotationInstaller _rotationInstaller;
        [SerializeField] private HealthInstaller _healthInstaller;
        [SerializeField, Required] private WeaponEntity _startWeapon;
        [SerializeField] private Transform[] _deathHideObjects;
        [SerializeField, MinValue(0)] private float _attackDistance = 1f;
        
        public override void Install(IEntity entity)
        {
            entity.AddTransform(_transform);
            entity.AddRigidbody(_rigidbody);
            entity.AddCollisionEventReceiver(_collisionEventReceiver);
            entity.AddBehaviour(new DeathObjectDisableBehaviour(_deathHideObjects));

            _moveInstaller.Install(entity);
            _rotationInstaller.Install(entity);
            _healthInstaller.Install(entity);
            
            InstallFollowBehaviour(entity);
            InstallAttack(entity);

            GameContext gameContext = GameContext.Instance;
            entity.WhenInit(() => gameContext.GetEnemies().Add(entity));
        }

        private void InstallFollowBehaviour(IEntity entity)
        {
            entity.AddTarget(new ReactiveVariable<Transform>());
            entity.AddBehaviour<TargetFollowBehaviour>();
        }
        
        private void InstallAttack(IEntity entity)
        {
            entity.AddCurrentWeapon(new ReactiveVariable<IWeaponEntity>(_startWeapon));
            
            entity.AddAttackCondition(new AndExpression(() => entity.IsAlive(),
                () => entity.GetTarget().Value != null,
                () => entity.IsExistsWeapon(out IWeaponEntity weapon) && weapon.GetAttackCondition().Invoke(),
                () => entity.CalculateDistanceToEntity(entity.GetTarget().Value) <= _attackDistance));

            int attackAnimatorTriggerHash = Animator.StringToHash(AnimatorParameters.AttackTriggerName);

            entity.AddAttackAction(new BaseAction(() =>
            {
                if (entity.GetAttackCondition().Invoke() == false)
                    return;
                
                entity.GetAnimator().SetTrigger(attackAnimatorTriggerHash);
            }));
            
            entity.AddAttackEvent(new BaseEvent());
            entity.AddBehaviour(new MeleeAttackBehaviour(AnimatorParameters.FireEventName));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackDistance);
        }
    }
}