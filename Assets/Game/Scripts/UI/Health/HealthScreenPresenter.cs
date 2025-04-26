using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.UI
{
    public class HealthScreenPresenter : HealthPresenter
    {
        [SerializeField, Required] private HealthScreen _healthScreen;
        
        protected override void OnInit()
        {
            base.OnInit();

            OnHealthChange();
        }

        protected override void OnHealthChange()
        {
            _healthScreen.ChangePercent(Health.GetPercent());
        }
    }
}