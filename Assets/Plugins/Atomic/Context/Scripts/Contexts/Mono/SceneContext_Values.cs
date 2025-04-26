using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial class SceneContext
    {
        public event Action<int, object> OnValueAdded
        {
            add => this.context.OnValueAdded += value;
            remove => this.context.OnValueAdded -= value;
        }

        public event Action<int, object> OnValueDeleted
        {
            add => this.context.OnValueDeleted += value;
            remove => this.context.OnValueDeleted -= value;
        }

        public event Action<int, object> OnValueChanged
        {
            add => this.context.OnValueChanged += value;
            remove => this.context.OnValueChanged -= value;
        }

        public event Action OnValuesCleared
        {
            add => this.context.OnValuesCleared += value;
            remove => this.context.OnValuesCleared -= value;
        }

        public IReadOnlyDictionary<int, object> Values => this.context.Values;

        public bool AddValue(int key, object value) => this.context.AddValue(key, value);

        public void SetValue(int key, object value) => this.context.SetValue(key, value);

        public bool DelValue(int key) => this.context.DelValue(key);

        public bool DelValue(int key, out object removed) => this.context.DelValue(key, out removed);

        public bool HasValue(int key) => this.context.HasValue(key);

        public T GetValue<T>(int key) => this.context.GetValue<T>(key);

        public object GetValue(int key) => this.context.GetValue(key);

        public bool TryGetValue<T>(int id, out T value) => this.context.TryGetValue(id, out value);

        public bool TryGetValue(int id, out object value) => this.context.TryGetValue(id, out value);
        
        public bool ClearValues() => this.context.ClearValues();
    }
}