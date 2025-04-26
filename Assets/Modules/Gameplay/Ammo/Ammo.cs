using System;
using UnityEngine;

namespace Modules.Gameplay
{
    [Serializable]
    public sealed class Ammo
    {
        [SerializeField, Min(0)] private int _count;

        public Ammo(int count)
        {
            _count = count;
        }

        public event Action StateChanged;

        public int GetCount()
        {
            return _count;
        }

        public bool IsExists()
        {
            return _count > 0;
        }

        public void Add(int charges)
        {
            _count += charges;
            StateChanged?.Invoke();
        }

        public bool TrySpend()
        {
            if (_count > 0)
            {
                _count--;
                StateChanged?.Invoke();

                return true;
            }

            return false;
        }
    }
}