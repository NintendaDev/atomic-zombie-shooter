using System;

namespace Atomic.Entities
{
    public partial class SceneEntityProxy<T>
    {
        public event Action OnInitialized
        {
            add => source.OnInitialized += value;
            remove => source.OnInitialized -= value;
        }

        public event Action OnEnabled
        {
            add => source.OnEnabled += value;
            remove => source.OnEnabled -= value;
        }

        public event Action OnDisabled
        {
            add => source.OnDisabled += value;
            remove => source.OnDisabled -= value;
        }

        public event Action OnDisposed
        {
            add => source.OnDisposed += value;
            remove => source.OnDisposed -= value;
        }

        public event Action<float> OnUpdated
        {
            add => source.OnUpdated += value;
            remove => source.OnUpdated -= value;
        }

        public event Action<float> OnFixedUpdated
        {
            add => source.OnFixedUpdated += value;
            remove => source.OnFixedUpdated -= value;
        }

        public event Action<float> OnLateUpdated
        {
            add => source.OnLateUpdated += value;
            remove => source.OnLateUpdated -= value;
        }
        
        public bool Initialized
        {
            get => source.Initialized;
        }

        public bool Enabled
        {
            get => source.Enabled;
            set => source.Enabled = value;
        }
        
        public void Init() => source.Init();
        public void Enable() => source.Enable();
        public void Disable() => source.Disable();
        public void Dispose() => source.Dispose();
        public void OnUpdate(in float deltaTime) => source.OnUpdate(in deltaTime);
        public void OnFixedUpdate(in float deltaTime) => source.OnFixedUpdate(in deltaTime);
        public void OnLateUpdate(in float deltaTime) => source.OnLateUpdate(in deltaTime);
    }
}