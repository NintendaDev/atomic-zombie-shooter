using System;

namespace Atomic.Entities
{
    internal sealed class DelegateUtils
    {
        internal static void Unsubscribe(ref Action action)
        {
            if (action == null)
                return;

            Delegate[] delegates = action.GetInvocationList();
            for (int i = 0, count = delegates.Length; i < count; i++)
                action -= (Action) delegates[i];

            action = null;
        }

        internal static void Unsubscribe<T>(ref Action<T> action)
        {
            if (action == null)
                return;

            Delegate[] delegates = action.GetInvocationList();
            for (int i = 0, count = delegates.Length; i < count; i++)
                action -= (Action<T>) delegates[i];

            action = null;
        }
    }
}