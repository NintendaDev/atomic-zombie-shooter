using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Atomic.Contexts.ContextUtils;

namespace Atomic.Contexts
{
    public static class ContextExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValues(this IContext context, in IReadOnlyDictionary<int, object> values)
        {
            if (values == null)
                return;

            foreach ((int key, object value) in values)
                context.AddValue(key, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddControllers(this IContext context, in IEnumerable<IContextController> systems)
        {
            if (systems == null)
                return;

            foreach (IContextController system in systems)
                context.AddController(system);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetValue<T>(this IContext context, string key)
        {
            return context.GetValue<T>(NameToId(key));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object GetValue(this IContext context, string key)
        {
            return context.GetValue(NameToId(key));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue<T>(this IContext context, string key, out T value)
        {
            return context.TryGetValue(NameToId(key), out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValue(this IContext context, string key, out object value)
        {
            return context.TryGetValue(NameToId(key), out value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddValue(this IContext context, string key, object value)
        {
            return context.AddValue(NameToId(key), value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelValue(this IContext context, string key)
        {
            return context.DelValue(NameToId(key));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelValue(this IContext context, string key, out object removed)
        {
            return context.DelValue(NameToId(key), out removed);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetValue(this IContext context, string key, object value)
        {
            context.SetValue(NameToId(key), value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasValue(this IContext context, string key)
        {
            return context.HasValue(NameToId(key));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValues(this IContext context, IReadOnlyDictionary<string, object> values)
        {
            if (values == null)
                return;

            foreach ((string key, object value) in values)
                context.AddValue(key, value);
        }

        public static void DisposeValues(this IContext context)
        {
            IEnumerable<object> values = context.Values.Values;
            foreach (object value in values)
                if (value is IDisposable disposable)
                    disposable.Dispose();
        }
    }
}