using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class HealthScreen : MonoBehaviour
    {
        private const float LowInjured = 0.75f;
        private const float MediumInjured = 0.5f;
        private const float HighInjured = 0.25f;
        private const float CriticalInjured = 0.10f;
        
        [SerializeField]
        private Image _staticIndication;

        [SerializeField]
        private Image _dynamicIndication;

        [SerializeField]
        private Image _takeDamageView;

        private Sequence _takeDamageTween;
        private Tweener _criticalTween;

        private void Awake()
        {
            _takeDamageView.color = new Color(1, 1, 1, 0);
            _dynamicIndication.color = new Color(1, 1, 1, 0);
        }

        public void ChangePercent(float percent)
        {
            switch (percent)
            {
                case > LowInjured:
                    DisableInjure();
                    break;
                
                case <= LowInjured and > MediumInjured:
                    SetLowInjure();
                    break;
                
                case <= MediumInjured and > HighInjured:
                    SetMediumInjure();
                    break;
                
                case <= HighInjured and > CriticalInjured:
                    SetHighInjure();
                    break;
                
                case <= CriticalInjured:
                    SetCriticalInjure();
                    break;
            }
        }

        public void TakeDamage(int damage)
        {
            if (_takeDamageTween != null)
            {
                _takeDamageTween.Kill();
            }

            _takeDamageTween = DOTween
                .Sequence()
                .Append(_takeDamageView.DOFade(Mathf.Clamp(damage / 40.0f, 0.2f, 1.0f), 0.05f))
                .Append(_takeDamageView.DOFade(0, 0.2f));
        }
        
        private void StartCriticalTween()
        {
            if (_criticalTween != null)
            {
                return;
            }
            
            _dynamicIndication.color = new Color(1, 1, 1, 0);
            _criticalTween = _dynamicIndication
                .DOFade(0.85f, 0.75f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }

        
        private void StopCriticalTween()
        {
            if (_criticalTween == null)
            {
                return;
            }

            _criticalTween.Kill();
            _criticalTween = null;
            _dynamicIndication.color = new Color(1, 1, 1, 0);
        }
        
        private void SetCriticalInjure()
        {
            _staticIndication.color = new Color(1, 1, 1, 0.8f);
            StartCriticalTween();
        }
       
        private void SetHighInjure()
        {
            _staticIndication.color = new Color(1, 1, 1, 0.6f);
            StopCriticalTween();
        }

        private void SetMediumInjure()
        {
            _staticIndication.color = new Color(1, 1, 1, 0.4f);
            StopCriticalTween();
        }

        private void SetLowInjure()
        {
            _staticIndication.color = new Color(1, 1, 1, 0.2f);
            StopCriticalTween();
        }

        private void DisableInjure()
        {
            _staticIndication.color = new Color(1, 1, 1, 0);
            StopCriticalTween();
        }
    }
}