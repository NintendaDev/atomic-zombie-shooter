using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        public event Action<IEntity, int> OnTagAdded
        {
            add => this.entity.OnTagAdded += value;
            remove => this.entity.OnTagAdded -= value;
        }

        public event Action<IEntity, int> OnTagDeleted
        {
            add => this.entity.OnTagDeleted += value;
            remove => this.entity.OnTagDeleted -= value;
        }

        public event Action<IEntity> OnTagsCleared
        {
            add => this.entity.OnTagsCleared += value;
            remove => this.entity.OnTagsCleared -= value;
        }

        public IReadOnlyCollection<int> Tags => this.entity.Tags;
        
        public bool DelTag(in int tag) => this.entity.DelTag(in tag);
        public bool HasTag(in int tag) => this.entity.HasTag(in tag);
        public bool AddTag(in int tag) => this.entity.AddTag(in tag);
        public bool ClearTags() => this.entity.ClearTags();
    }
}