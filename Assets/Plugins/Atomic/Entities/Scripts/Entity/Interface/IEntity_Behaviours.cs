using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial interface IEntity
    {
        event Action<IEntity, IEntityBehaviour> OnBehaviourAdded;
        event Action<IEntity, IEntityBehaviour> OnBehaviourDeleted;
        event Action<IEntity> OnBehavioursCleared;

        IReadOnlyCollection<IEntityBehaviour> Behaviours { get; }
        
        bool AddBehaviour(in IEntityBehaviour behaviour);
        bool DelBehaviour(in IEntityBehaviour behaviour);
        bool HasBehaviour(in IEntityBehaviour behaviour);
        bool ClearBehaviours();
    }
}