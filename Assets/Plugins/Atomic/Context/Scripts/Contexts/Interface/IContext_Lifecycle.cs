using System;

namespace Atomic.Contexts
{
    public partial interface IContext
    {
        event Action OnInitiazized;
        event Action OnEnabled;
        event Action OnDisabled;
        event Action OnDisposed;
        
        event Action<float> OnUpdated;
        event Action<float> OnFixedUpdated;
        event Action<float> OnLateUpdated;

        bool Initialized { get; }
        bool Enabled { get; }
        
        void Init();
        void Enable();
        void Disable();
        void Dispose();
        
        void OnUpdate(float deltaTime);
        void OnFixedUpdate(float deltaTime);
        void OnLateUpdate(float deltaTime);
    }
}