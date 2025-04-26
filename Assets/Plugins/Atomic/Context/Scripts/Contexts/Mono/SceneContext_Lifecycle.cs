using System;

namespace Atomic.Contexts
{
    public partial class SceneContext
    {
        public event Action OnInitiazized
        {
            add => this.context.OnInitiazized += value;
            remove => this.context.OnInitiazized -= value;
        }

        public event Action OnEnabled
        {
            add => this.context.OnEnabled += value;
            remove => this.context.OnEnabled -= value;
        }

        public event Action OnDisabled
        {
            add => this.context.OnDisabled += value;
            remove => this.context.OnDisabled -= value;
        }

        public event Action OnDisposed
        {
            add => this.context.OnDisposed += value;
            remove => this.context.OnDisposed -= value;
        }

        public event Action<float> OnUpdated
        {
            add => this.context.OnUpdated += value;
            remove => this.context.OnUpdated -= value;
        }

        public event Action<float> OnFixedUpdated
        {
            add => this.context.OnFixedUpdated += value;
            remove => this.context.OnFixedUpdated -= value;
        }

        public event Action<float> OnLateUpdated
        {
            add => this.context.OnLateUpdated += value;
            remove => this.context.OnLateUpdated -= value;
        }

        public bool Initialized => this.context.Initialized;
        
        public bool Enabled => this.context.Enabled;

        public void Init() => this.context.Init();
        
        public void Enable() => this.context.Enable();
        
        public void Disable() => this.context.Disable();
        
        public void Dispose() => this.context.Dispose();
        
        public void OnUpdate(float deltaTime) => this.context.OnUpdate(deltaTime);
        
        public void OnFixedUpdate(float deltaTime) => this.context.OnFixedUpdate(deltaTime);
        
        public void OnLateUpdate(float deltaTime) => this.context.OnLateUpdate(deltaTime);
    }
}