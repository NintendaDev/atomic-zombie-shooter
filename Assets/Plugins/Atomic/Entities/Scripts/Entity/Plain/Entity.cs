using System;
using System.Collections.Generic;
using UnityEditor;

// ReSharper disable UnusedMember.Global

namespace Atomic.Entities
{
    public partial class Entity : IEntity
    {
        private static int idGenerator;

        public int InstanceId
        {
            get { return this.instanceId; }
            internal set { instanceId = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private readonly IEntity owner;
        private int instanceId;
        private string name;

        public Entity(
            in string name = null,
            in IEnumerable<int> tags = null,
            in IDictionary<int, object> values = null,
            in IEnumerable<IEntityBehaviour> behaviours = null,
            in IEntity owner = null
        )
        {
            this.instanceId = ++idGenerator;
            this.name = name ?? string.Empty;
            this.tags = tags == null
                ? new HashSet<int>()
                : new HashSet<int>(tags);
            this.values = values == null
                ? new Dictionary<int, object>()
                : new Dictionary<int, object>(values);
            this.behaviours = behaviours == null
                ? new HashSet<IEntityBehaviour>()
                : new HashSet<IEntityBehaviour>(behaviours);
            
            this.owner = owner ?? this;
        }

        public override string ToString()
        {
            return $"{nameof(name)}: {this.name}";
        }

        private bool Equals(Entity other)
        {
            return this.instanceId == other.instanceId;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Entity other && Equals(other);
        }

        public override int GetHashCode()
        {
            return this.instanceId;
        }

        public void Clear()
        {
            this.ClearTags();
            this.ClearValues();
            this.ClearBehaviours();
        }
        
#if UNITY_EDITOR
        [InitializeOnEnterPlayMode]
        private static void OnEnterPlayMode()
        {
            idGenerator = 0;
        }
#endif
    }
}