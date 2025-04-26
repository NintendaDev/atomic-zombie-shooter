using Atomic.Elements;
using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Contexts.Player;
using Game.Gameplay.Entity;
using Game.Gameplay.Weapons;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.UI
{
    public sealed class AmmoPresenter : Presenter
    {
        [SerializeField, Required] private StatView _ammoStatView;
        
        private IReactiveVariable<IWeaponEntity> _currentWeapon;
        private Ammo _currentAmmo;

        protected override void OnInit()
        {
            base.OnInit();
            
            IEntity character = GameContext.Instance.GetPlayerContext().GetCharacter();
            _currentWeapon = character.GetCurrentWeapon();

            _currentWeapon.Subscribe(OnCurrentWeaponChange);

            if (_currentWeapon.Value != null)
                OnCurrentWeaponChange(_currentWeapon.Value);
        }

        protected override void OnDispose()
        {
            if (_currentAmmo != null)
                _currentAmmo.StateChanged -= OnAmmoChange;
            
            _currentWeapon.Unsubscribe(OnCurrentWeaponChange);
        }

        private void OnCurrentWeaponChange(IWeaponEntity nextWeapon)
        {
            if (_currentAmmo != null)
                _currentAmmo.StateChanged -= OnAmmoChange;
            
            _currentAmmo = nextWeapon.GetAmmo();
            _currentAmmo.StateChanged += OnAmmoChange;
            
            UpdateAmmoStatView();
        }

        private void UpdateAmmoStatView() => _ammoStatView.SetText(_currentAmmo.GetCount().ToString());

        private void OnAmmoChange() => UpdateAmmoStatView();
    }
}