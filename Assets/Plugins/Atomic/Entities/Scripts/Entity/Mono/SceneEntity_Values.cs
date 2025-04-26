using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        public event Action<IEntity, int, object> OnValueAdded
        {
            add => this.entity.OnValueAdded += value;
            remove => this.entity.OnValueAdded -= value;
        }

        public event Action<IEntity, int, object> OnValueDeleted
        {
            add => this.entity.OnValueDeleted += value;
            remove => this.entity.OnValueDeleted -= value;
        }

        public event Action<IEntity, int, object> OnValueChanged
        {
            add => this.entity.OnValueChanged += value;
            remove => this.entity.OnValueChanged -= value;
        }

        public event Action<IEntity> OnValuesCleared
        {
            add => this.entity.OnValuesCleared += value;
            remove => this.entity.OnValuesCleared -= value;
        }

        public IReadOnlyDictionary<int, object> Values => this.entity.Values;

        public T GetValue<T>(in int id) => this.entity.GetValue<T>(in id);
        public object GetValue(in int id) => this.entity.GetValue(in id);
        public bool TryGetValue<T>(in int id, out T value) => this.entity.TryGetValue(in id, out value);
        public bool TryGetValue(in int id, out object value) => this.entity.TryGetValue(in id, out value);
        public bool AddValue(in int id, in object value) => this.entity.AddValue(in id, in value);
        public bool DelValue(in int id) => this.entity.DelValue(in id);
        public bool DelValue(in int id, out object removed) => this.entity.DelValue(in id, out removed);
        public bool HasValue(in int id) => this.entity.HasValue(in id);
        public void SetValue(in int id, in object value) => this.entity.SetValue(in id, in value);
        public void SetValue(in int id, in object value, out object previous) =>
            this.entity.SetValue(in id, in value, out previous);
        public bool ClearValues() => this.entity.ClearValues();
    }
}