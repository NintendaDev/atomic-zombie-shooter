using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class Entity
    {
        public event Action OnInitialized;
        public event Action OnEnabled;
        public event Action OnDisabled;
        public event Action OnDisposed;

        public event Action<float> OnUpdated;
        public event Action<float> OnFixedUpdated;
        public event Action<float> OnLateUpdated;

        public bool Initialized
        {
            get { return initialized; }
        }

        public bool Enabled
        {
            get { return this.enabled; }
            set
            {
                if (value)
                    this.Enable();
                else
                    this.Disable();
            }
        }

        private bool initialized;
        private bool enabled;

        private readonly List<IEntityUpdate> updates = new();
        private readonly List<IEntityFixedUpdate> fixedUpdates = new();
        private readonly List<IEntityLateUpdate> lateUpdates = new();

        private readonly List<IEntityUpdate> _updateCache = new();
        private readonly List<IEntityFixedUpdate> _fixedUpdateCache = new();
        private readonly List<IEntityLateUpdate> _lateUpdateCache = new();

        public void Init()
        {
            if (this.initialized)
                return;

            foreach (IEntityBehaviour behaviour in this.behaviours)
                if (behaviour is IEntityInit initBehaviour)
                    initBehaviour.Init(this.owner);

            this.initialized = true;
            this.OnInitialized?.Invoke();
        }

        public void Dispose()
        {
            if (!this.initialized)
                return;

            if (this.enabled) 
                this.Disable();

            foreach (IEntityBehaviour behaviour in this.behaviours)
                if (behaviour is IEntityDispose entityDispose)
                    entityDispose.Dispose(this.owner);


            this.initialized = false;
            this.OnDisposed?.Invoke();

            //Auto unsubscribe events:
            DelegateUtils.Unsubscribe(ref this.OnInitialized);
            DelegateUtils.Unsubscribe(ref this.OnEnabled);
            DelegateUtils.Unsubscribe(ref this.OnDisabled);
            DelegateUtils.Unsubscribe(ref this.OnUpdated);
            DelegateUtils.Unsubscribe(ref this.OnFixedUpdated);
            DelegateUtils.Unsubscribe(ref this.OnLateUpdated);
            DelegateUtils.Unsubscribe(ref this.OnDisposed);
        }

        public void Enable()
        {
            if (this.enabled)
                return;

            if (!this.initialized) 
                this.Init();

            this.enabled = true;

            foreach (IEntityBehaviour behaviour in this.behaviours)
            {
                if (behaviour is IEntityEnable entityEnable) entityEnable.Enable(this.owner);
                if (behaviour is IEntityUpdate update) this.updates.Add(update);
                if (behaviour is IEntityFixedUpdate fixedUpdate) this.fixedUpdates.Add(fixedUpdate);
                if (behaviour is IEntityLateUpdate lateUpdate) this.lateUpdates.Add(lateUpdate);
            }

            this.OnEnabled?.Invoke();
        }

        public void Disable()
        {
            if (!this.enabled)
                return;

            foreach (IEntityBehaviour behaviour in this.behaviours)
            {
                if (behaviour is IEntityDisable entityDisable) entityDisable.Disable(this.owner);
                if (behaviour is IEntityUpdate update) this.updates.Remove(update);
                if (behaviour is IEntityFixedUpdate fixedUpdate) this.fixedUpdates.Remove(fixedUpdate);
                if (behaviour is IEntityLateUpdate lateUpdate) this.lateUpdates.Remove(lateUpdate);
            }

            this.enabled = false;
            this.OnDisabled?.Invoke();
        }

        public void OnUpdate(in float deltaTime)
        {
            if (!this.enabled)
                return;

            int count = this.updates.Count;
            if (count != 0)
            {
                _updateCache.Clear();
                _updateCache.AddRange(this.updates);

                for (int i = 0; i < count; i++)
                {
                    IEntityUpdate update = _updateCache[i];
                    update.OnUpdate(this.owner, in deltaTime);
                }
            }

            this.OnUpdated?.Invoke(deltaTime);
        }

        public void OnFixedUpdate(in float deltaTime)
        {
            if (!this.enabled)
                return;

            int count = this.fixedUpdates.Count;
            if (count != 0)
            {
                _fixedUpdateCache.Clear();
                _fixedUpdateCache.AddRange(this.fixedUpdates);

                for (int i = 0; i < count; i++)
                {
                    IEntityFixedUpdate fixedUpdate = _fixedUpdateCache[i];
                    fixedUpdate.OnFixedUpdate(this.owner, in deltaTime);
                }
            }

            this.OnFixedUpdated?.Invoke(deltaTime);
        }

        public void OnLateUpdate(in float deltaTime)
        {
            if (!this.enabled)
                return;

            int count = this.lateUpdates.Count;
            if (count != 0)
            {
                _lateUpdateCache.Clear();
                _lateUpdateCache.AddRange(this.lateUpdates);

                for (int i = 0; i < count; i++)
                {
                    IEntityLateUpdate lateUpdate = _lateUpdateCache[i];
                    lateUpdate.OnLateUpdate(this.owner, in deltaTime);
                }
            }

            this.OnLateUpdated?.Invoke(deltaTime);
        }
    }
}