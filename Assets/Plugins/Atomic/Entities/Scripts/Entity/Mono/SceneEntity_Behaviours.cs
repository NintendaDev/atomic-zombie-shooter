using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        public event Action<IEntity, IEntityBehaviour> OnBehaviourAdded
        {
            add => this.entity.OnBehaviourAdded += value;
            remove => this.entity.OnBehaviourAdded -= value;
        }

        public event Action<IEntity, IEntityBehaviour> OnBehaviourDeleted
        {
            add => this.entity.OnBehaviourDeleted += value;
            remove => this.entity.OnBehaviourDeleted -= value;
        }

        public event Action<IEntity> OnBehavioursCleared
        {
            add => this.entity.OnBehavioursCleared += value;
            remove => this.entity.OnBehavioursCleared -= value;
        }

        public IReadOnlyCollection<IEntityBehaviour> Behaviours => this.entity.Behaviours;

        public bool AddBehaviour(in IEntityBehaviour behaviour) => this.entity.AddBehaviour(in behaviour);
        public bool DelBehaviour(in IEntityBehaviour behaviour) => this.entity.DelBehaviour(in behaviour);
        public bool HasBehaviour(in IEntityBehaviour behaviour) => this.entity.HasBehaviour(in behaviour);
        public bool ClearBehaviours() => this.entity.ClearBehaviours();
    }
}