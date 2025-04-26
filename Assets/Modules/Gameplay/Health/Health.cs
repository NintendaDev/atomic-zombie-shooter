using System;
using Sirenix.OdinInspector;

namespace Modules.Gameplay
{
    [Serializable]
    public sealed class Health
    {
        private int _currentValue;
        private int _maxValue;
        
        public Health(int health, int maxValue)
        {
            _maxValue = maxValue;
            _currentValue = Math.Clamp(health, 0, _maxValue);
        }
        
        public event Action StateChanged;
        
        public event Action<int> HealthChanged;
        
        public event Action<int> MaxHealthChanged;
        
        public event Action HealthEmpty;

        public int GetCurrentValue()
        {
            return _currentValue;
        }

        public int GetMaxValue()
        {
            return _maxValue;
        }

        public bool IsEmpty()
        {
            return _currentValue == 0;
        }

        public bool IsFull()
        {
            return _currentValue == _maxValue;
        }

        public bool IsExists()
        {
            return _currentValue > 0;
        }

        public float GetPercent()
        {
            return (float)_currentValue / _maxValue;
        }

        [Button, HideInEditorMode]
        public bool Add(int range)
        {
            if (range <= 0)
                return false;
            
            if (_currentValue == _maxValue)
                return false;
            
            _currentValue = Math.Min(_currentValue + range, _maxValue);
            StateChanged?.Invoke();
            HealthChanged?.Invoke(_currentValue);

            return true;
        }

        [Button, HideInEditorMode]
        public bool Reduce(int range)
        {
            if (range < 0)
                throw new Exception($"Range can't be less than zero! Actual range {range}");

            if (_currentValue == 0)
                return false;

            if (range == 0)
                return false;

            _currentValue = Math.Max(0, _currentValue - range);
            StateChanged?.Invoke();
            HealthChanged?.Invoke(_currentValue);

            if (_currentValue == 0) 
                HealthEmpty?.Invoke();

            return true;
        }

        [Button, HideInEditorMode]
        public void SetCurrent(int health)
        {
            if (_currentValue == health)
                return;

            _currentValue = Math.Clamp(health, 0, _maxValue);
            StateChanged?.Invoke();
            HealthChanged?.Invoke(_currentValue);
            
            if (_currentValue == 0)
                HealthEmpty?.Invoke();
        }

        [Button, HideInEditorMode]
        public void SetMax(int maxHealth)
        {
            if (_maxValue == maxHealth)
                return;

            _maxValue = Math.Max(1, maxHealth);
            MaxHealthChanged?.Invoke(_maxValue);

            int newHealth = Math.Min(_currentValue, _maxValue);
            
            if (newHealth != _currentValue)
            {
                _currentValue = newHealth;
                HealthChanged?.Invoke(newHealth);
            }
            
            StateChanged?.Invoke();
        }
    }
}