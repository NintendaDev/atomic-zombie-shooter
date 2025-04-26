using Atomic.Entities;
using Game.Gameplay.Weapons;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Common
{
    public sealed class MeleeAttackBehaviour : IEntityInit, IEntityDispose, IEntityFixedUpdate
    {
        private readonly string _fireAnimationEventName;
        private AnimationEventReceiver _animatorEventReceiver;
        private IEntity _attackerEntity;
        private IWeaponEntity _currentWeapon;

        public MeleeAttackBehaviour(string fireAnimationEventName)
        {
            _fireAnimationEventName = fireAnimationEventName;
        }

        public void Init(in IEntity entity)
        {
            _attackerEntity = entity;
            _animatorEventReceiver = _attackerEntity.GetAnimationEventReceiver();
            _currentWeapon = _attackerEntity.GetCurrentWeapon().Value;
            
            _attackerEntity.GetCurrentWeapon().Subscribe(OnWeaponChange);
            _animatorEventReceiver.Subscribe(_fireAnimationEventName, OnFireEvent);
        }

        public void Dispose(in IEntity entity)
        {
            _attackerEntity.GetCurrentWeapon().Unsubscribe(OnWeaponChange);
            _animatorEventReceiver.Unsubscribe(_fireAnimationEventName, OnFireEvent);
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            entity.GetAttackAction().Invoke();
        }

        private void OnWeaponChange(IWeaponEntity nextWeapon) => _currentWeapon = nextWeapon;

        private void OnFireEvent() => MeleeUseCase.AttackBy(_currentWeapon);
    }
}