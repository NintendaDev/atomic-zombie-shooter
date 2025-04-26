using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial interface IContext
    {
        event Action<int, object> OnValueAdded;
        event Action<int, object> OnValueDeleted;
        event Action<int, object> OnValueChanged;
        event Action OnValuesCleared;

        IReadOnlyDictionary<int, object> Values { get; }

        bool AddValue(int key, object value);
        void SetValue(int key, object value);
        bool DelValue(int key);
        bool DelValue(int key, out object removed);
        bool HasValue(int key);

        T GetValue<T>(int key);
        object GetValue(int key);
        bool TryGetValue<T>(int id, out T value);
        bool TryGetValue(int id, out object value);

        bool ClearValues();
    }
}