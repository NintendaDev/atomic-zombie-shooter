using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class Entity
    {
        public event Action<IEntity, int, object> OnValueAdded;
        public event Action<IEntity, int, object> OnValueDeleted;
        public event Action<IEntity, int, object> OnValueChanged;
        public event Action<IEntity> OnValuesCleared;

        public IReadOnlyDictionary<int, object> Values => this.values;

        private readonly Dictionary<int, object> values;

        public T GetValue<T>(in int id)
        {
            return this.values.TryGetValue(id, out object value)
                ? (T) value
                : throw new KeyNotFoundException($"The given id {EntityUtils.IdToName(id)} was not present in the values. Entity: {name}");
        }

        public bool TryGetValue<T>(in int id, out T value)
        {
            if (this.values.TryGetValue(id, out object v))
            {
                value = (T) v;
                return true;
            }

            value = default;
            return false;
        }

        public object GetValue(in int id)
        {
            return this.values.TryGetValue(id, out object value)
                ? value
                : throw new KeyNotFoundException($"The given id {EntityUtils.IdToName(id)} was not present in the values. Entity: {name}");
        }

        public bool TryGetValue(in int id, out object value)
        {
            return this.values.TryGetValue(id, out value);
        }

        public bool HasValue(in int id)
        {
            return this.values.ContainsKey(id);
        }

        public void SetValue(in int id, in object value, out object previous)
        {
            if (this.values.TryGetValue(id, out previous))
            {
                this.values[id] = value;
                this.OnValueChanged?.Invoke(this, id, value);
            }
            else
            {
                this.AddValue(in id, in value);
            }
        }

        public void SetValue(in int id, in object value)
        {
            if (this.values.ContainsKey(id))
            {
                this.values[id] = value;
                this.OnValueChanged?.Invoke(this, id, value);
            }
            else
            {
                this.AddValue(in id, in value);
            }
        }

        public bool AddValue(in int id, in object value)
        {
            if (this.values.TryAdd(id, value))
            {
                this.OnValueAdded?.Invoke(this, id, value);
                return true;
            }

            return false;
        }

        public bool DelValue(in int id)
        {
            if (this.values.Remove(id, out object removed))
            {
                this.OnValueDeleted?.Invoke(this, id, removed);
                return true;
            }

            return false;
        }

        public bool DelValue(in int id, out object removed)
        {
            if (this.values.Remove(id, out removed))
            {
                this.OnValueDeleted?.Invoke(this, id, removed);
                return true;
            }

            return false;
        }

        public bool ClearValues()
        {
            if (this.values.Count == 0)
                return false;

            this.values.Clear();
            this.OnValuesCleared?.Invoke(this);
            return true;
        }
    }
}