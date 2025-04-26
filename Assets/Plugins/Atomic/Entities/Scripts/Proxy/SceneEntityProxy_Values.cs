using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class SceneEntityProxy<T>
    {
        public event Action<IEntity, int, object> OnValueAdded
        {
            add => source.OnValueAdded += value;
            remove => source.OnValueAdded -= value;
        }

        public event Action<IEntity, int, object> OnValueDeleted
        {
            add => source.OnValueDeleted += value;
            remove => source.OnValueDeleted -= value;
        }

        public event Action<IEntity, int, object> OnValueChanged
        {
            add => source.OnValueChanged += value;
            remove => source.OnValueChanged -= value;
        }

        public event Action<IEntity> OnValuesCleared
        {
            add => source.OnValuesCleared += value;
            remove => source.OnValuesCleared -= value;
        }
        
        public IReadOnlyDictionary<int, object> Values => source.Values;

        public T GetValue<T>(in int id) => source.GetValue<T>(id);
        public object GetValue(in int id) => source.GetValue(id);
        public bool TryGetValue<T>(in int id, out T value) => source.TryGetValue(in id, out value);
        public bool TryGetValue(in int id, out object value) => source.TryGetValue(in id, out value);
        public bool AddValue(in int id, in object value) => source.AddValue(in id, in value);
        public void SetValue(in int id, in object value) => source.SetValue(in id, in value);
        public void SetValue(in int id, in object value, out object previous) => source.SetValue(in id, in value, out previous);
        public bool DelValue(in int id) => source.DelValue(in id);
        public bool DelValue(in int id, out object removed) => source.DelValue(in id, out removed);
        public bool HasValue(in int id) => source.HasValue(in id);
        public bool ClearValues() => source.ClearValues();
    }
}