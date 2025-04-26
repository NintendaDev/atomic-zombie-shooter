namespace Atomic.Contexts
{
    public abstract class SingletonContext<T> : Context where T : Context, new()
    {
        public static T Instance => _instance ??= new T();

        private static T _instance;
    }
}