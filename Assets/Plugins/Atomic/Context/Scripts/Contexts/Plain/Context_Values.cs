using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial class Context
    {
        public event Action<int, object> OnValueAdded;
        public event Action<int, object> OnValueDeleted;
        public event Action<int, object> OnValueChanged;
        public event Action OnValuesCleared;

        public IReadOnlyDictionary<int, object> Values => this.values;

        private readonly Dictionary<int, object> values = new();

        public bool HasValue(int key)
        {
            return this.values.ContainsKey(key);
        }

        public T GetValue<T>(int key)
        {
            if (this.values.TryGetValue(key, out object value))
            {
                return (T) value;
            }

            return default;
        }

        public object GetValue(int key)
        {
            if (this.values.TryGetValue(key, out var value))
            {
                return value;
            }

            return null;
        }

        public bool TryGetValue<T>(int id, out T value)
        {
            if (this.values.TryGetValue(id, out object field))
            {
                value = (T) field;
                return true;
            }

            value = default;
            return false;
        }

        public bool TryGetValue(int id, out object value)
        {
            return this.values.TryGetValue(id, out value);
        }

     
        public bool AddValue(int key, object value)
        {
            if (this.values.TryAdd(key, value))
            {
                this.OnValueAdded?.Invoke(key, value);
                return true;
            }

            return false;
        }

        public void SetValue(int key, object value)
        {
            this.values[key] = value;
            this.OnValueChanged?.Invoke(key, value);
        }

        public bool DelValue(int key)
        {
            if (this.values.Remove(key, out object removed))
            {
                this.OnValueDeleted?.Invoke(key, removed);
                return true;
            }

            return false;
        }

        public bool DelValue(int key, out object removed)
        {
            if (this.values.Remove(key, out removed))
            {
                this.OnValueDeleted?.Invoke(key, removed);
                return true;
            }

            return false;
        }
        
        public bool ClearValues()
        {
            if (this.values.Count <= 0)
                return false;
            
            this.values.Clear();
            this.OnValuesCleared?.Invoke();
            return true;
        }
    }
}