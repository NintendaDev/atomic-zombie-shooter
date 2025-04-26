using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class Entity
    {
        public event Action<IEntity, IEntityBehaviour> OnBehaviourAdded;
        public event Action<IEntity, IEntityBehaviour> OnBehaviourDeleted;
        public event Action<IEntity> OnBehavioursCleared;

        public IReadOnlyCollection<IEntityBehaviour> Behaviours => this.behaviours;

        private readonly HashSet<IEntityBehaviour> behaviours;

        public bool HasBehaviour(in IEntityBehaviour behaviour)
        {
            return this.behaviours.Contains(behaviour);
        }

        public bool AddBehaviour(in IEntityBehaviour behaviour)
        {
            if (!this.behaviours.Add(behaviour))
                return false;

            if (this.initialized && behaviour is IEntityInit initBehaviour) initBehaviour.Init(this.owner);

            if (this.enabled)
            {
                if (behaviour is IEntityEnable enableBehaviour) enableBehaviour.Enable(this.owner);
                if (behaviour is IEntityUpdate update) this.updates.Add(update);
                if (behaviour is IEntityFixedUpdate fixedUpdate) this.fixedUpdates.Add(fixedUpdate);
                if (behaviour is IEntityLateUpdate lateUpdate) this.lateUpdates.Add(lateUpdate);
            }

            this.OnBehaviourAdded?.Invoke(this, behaviour);
            return true;
        }

        public bool DelBehaviour(in IEntityBehaviour behaviour)
        {
            if (!this.behaviours.Remove(behaviour))
                return false;

            if (this.enabled)
            {
                if (behaviour is IEntityUpdate update) this.updates.Remove(update);
                if (behaviour is IEntityFixedUpdate fixedUpdate) this.fixedUpdates.Remove(fixedUpdate);
                if (behaviour is IEntityLateUpdate lateUpdate) this.lateUpdates.Remove(lateUpdate);
                if (behaviour is IEntityDisable disable) disable.Disable(this.owner);
            }

            if (this.initialized && behaviour is IEntityDispose dispose) dispose.Dispose(this.owner);

            this.OnBehaviourDeleted?.Invoke(this, behaviour);
            return true;
        }

        public bool ClearBehaviours()
        {
            if (this.behaviours.Count == 0)
                return false;

            this.behaviours.Clear();
            this.OnBehavioursCleared?.Invoke(this);
            return true;
        }
    }
}