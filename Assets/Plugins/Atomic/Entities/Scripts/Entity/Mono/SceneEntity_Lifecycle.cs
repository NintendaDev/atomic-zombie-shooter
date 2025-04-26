using System;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        public event Action OnInitialized
        {
            add => this.entity.OnInitialized += value;
            remove => this.entity.OnInitialized -= value;
        }

        public event Action OnDisposed
        {
            add => this.entity.OnDisposed += value;
            remove => this.entity.OnDisposed -= value;
        }

        public event Action OnEnabled
        {
            add => this.entity.OnEnabled += value;
            remove => this.entity.OnEnabled -= value;
        }

        public event Action OnDisabled
        {
            add => this.entity.OnDisabled += value;
            remove => this.entity.OnDisabled -= value;
        }

        public event Action<float> OnUpdated
        {
            add => this.entity.OnUpdated += value;
            remove => this.entity.OnUpdated -= value;
        }

        public event Action<float> OnFixedUpdated
        {
            add => this.entity.OnFixedUpdated += value;
            remove => this.entity.OnFixedUpdated -= value;
        }

        public event Action<float> OnLateUpdated
        {
            add => this.entity.OnLateUpdated += value;
            remove => this.entity.OnLateUpdated -= value;
        }

        public bool Initialized => this.entity.Initialized;

        public bool Enabled
        {
            get => this.entity.Enabled;
            set => this.enabled = value;
        }

        public void Init() => this.entity.Init();
        public void Enable() => this.entity.Enable();
        public void Disable() => this.entity.Disable();
        public void Dispose() => this.entity.Dispose();
        public void OnUpdate(in float deltaTime) => this.entity.OnUpdate(in deltaTime);
        public void OnFixedUpdate(in float deltaTime) => this.entity.OnFixedUpdate(in deltaTime);
        public void OnLateUpdate(in float deltaTime) => this.entity.OnLateUpdate(in deltaTime);
    }
}