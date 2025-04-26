using System;

namespace Atomic.Entities
{
    public partial interface IEntity
    {
        event Action OnInitialized;
        event Action OnDisposed;
        event Action OnEnabled;
        event Action OnDisabled;

        event Action<float> OnUpdated;
        event Action<float> OnFixedUpdated;
        event Action<float> OnLateUpdated; 

        bool Initialized { get; }
        bool Enabled { get; }

        void Init();
        void Enable();
        void Disable();
        void Dispose();
        
        void OnUpdate(in float deltaTime);
        void OnFixedUpdate(in float deltaTime);
        void OnLateUpdate(in float deltaTime);
    }
}