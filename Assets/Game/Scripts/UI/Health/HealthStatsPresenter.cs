using System.ComponentModel.DataAnnotations;
using UnityEngine;

namespace Game.UI
{
    public class HealthStatsPresenter : HealthPresenter
    {
        [SerializeField, Required] private StatView _healthStatView;

        protected override void OnInit()
        {
            base.OnInit();
            
            UpdateHealthStatView();
        }

        protected override void OnHealthChange()
        {
            UpdateHealthStatView();
        }

        private void UpdateHealthStatView() => _healthStatView.SetText(Health.GetCurrentValue().ToString());
    }
}