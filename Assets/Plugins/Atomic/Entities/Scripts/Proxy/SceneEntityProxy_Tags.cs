using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class SceneEntityProxy<T>
    {
        public event Action<IEntity, int> OnTagAdded
        {
            add => source.OnTagAdded += value;
            remove => source.OnTagAdded -= value;
        }

        public event Action<IEntity, int> OnTagDeleted
        {
            add => source.OnTagDeleted += value;
            remove => source.OnTagDeleted -= value;
        }

        public event Action<IEntity> OnTagsCleared
        {
            add => source.OnTagsCleared += value;
            remove => source.OnTagsCleared -= value;
        }

        public IReadOnlyCollection<int> Tags => source.Tags;

        public bool HasTag(in int tag) => source.HasTag(in tag);
        public bool AddTag(in int tag) => source.AddTag(in tag);
        public bool DelTag(in int tag) => source.DelTag(in tag);
        public bool ClearTags() => source.ClearTags();
    }
}