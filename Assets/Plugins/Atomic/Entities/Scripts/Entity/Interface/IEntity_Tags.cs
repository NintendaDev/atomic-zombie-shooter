using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial interface IEntity
    {
        event Action<IEntity, int> OnTagAdded;
        event Action<IEntity, int> OnTagDeleted;
        event Action<IEntity> OnTagsCleared;

        IReadOnlyCollection<int> Tags { get; }
        
        bool HasTag(in int tag);
        bool AddTag(in int tag);
        bool DelTag(in int tag);
        bool ClearTags();
    }
}