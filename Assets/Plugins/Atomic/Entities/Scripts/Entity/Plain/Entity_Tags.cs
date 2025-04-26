using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class Entity
    {
        public event Action<IEntity, int> OnTagAdded;
        public event Action<IEntity, int> OnTagDeleted;
        public event Action<IEntity> OnTagsCleared;

        public IReadOnlyCollection<int> Tags => this.tags;

        private readonly HashSet<int> tags;

        public bool HasTag(in int tag)
        {
            return this.tags.Contains(tag);
        }

        public bool AddTag(in int tag)
        {
            if (this.tags.Add(tag))
            {
                this.OnTagAdded?.Invoke(this, tag);
                return true;
            }

            return false;
        }

        public bool DelTag(in int tag)
        {
            if (this.tags.Remove(tag))
            {
                this.OnTagDeleted?.Invoke(this, tag);
                return true;
            }

            return false;
        }

        public bool ClearTags()
        {
            if (this.tags.Count == 0)
            {
                return false;
            }

            this.tags.Clear();
            this.OnTagsCleared?.Invoke(this);
            return true;
        }
    }
}