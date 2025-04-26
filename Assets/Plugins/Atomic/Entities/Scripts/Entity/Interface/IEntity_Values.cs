using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial interface IEntity
    {
        event Action<IEntity, int, object> OnValueAdded;
        event Action<IEntity, int, object> OnValueDeleted;
        event Action<IEntity, int, object> OnValueChanged; 
        event Action<IEntity> OnValuesCleared;

        IReadOnlyDictionary<int, object> Values { get; }

        T GetValue<T>(in int id);
        object GetValue(in int id);
        bool TryGetValue<T>(in int id, out T value);
        bool TryGetValue(in int id, out object value);

        bool AddValue(in int id, in object value);
        bool DelValue(in int id);
        bool DelValue(in int id, out object removed);
        
        void SetValue(in int id, in object value);
        void SetValue(in int id, in object value, out object previous);

        bool HasValue(in int id);
        bool ClearValues();
    }
}