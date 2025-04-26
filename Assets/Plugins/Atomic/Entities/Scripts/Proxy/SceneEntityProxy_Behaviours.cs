using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class SceneEntityProxy<T>
    {
        public event Action<IEntity, IEntityBehaviour> OnBehaviourAdded
        {
            add => source.OnBehaviourAdded += value;
            remove => source.OnBehaviourAdded -= value;
        }

        public event Action<IEntity, IEntityBehaviour> OnBehaviourDeleted
        {
            add => source.OnBehaviourDeleted += value;
            remove => source.OnBehaviourDeleted -= value;
        }

        public event Action<IEntity> OnBehavioursCleared
        {
            add => source.OnBehavioursCleared += value;
            remove => source.OnBehavioursCleared -= value;
        }

        public IReadOnlyCollection<IEntityBehaviour> Behaviours => source.Behaviours;

        public bool AddBehaviour(in IEntityBehaviour behaviour) => source.AddBehaviour(in behaviour);
        public bool DelBehaviour(in IEntityBehaviour behaviour) => source.DelBehaviour(in behaviour);
        public bool HasBehaviour(in IEntityBehaviour behaviour) => source.HasBehaviour(in behaviour);
        public bool ClearBehaviours() => source.ClearBehaviours();
    }
}