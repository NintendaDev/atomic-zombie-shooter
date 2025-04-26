using UnityEngine;

namespace Atomic.Entities
{
    [AddComponentMenu("Atomic/Entities/Entity Proxy")]
    [DisallowMultipleComponent]
    public class SceneEntityProxy : SceneEntityProxy<SceneEntity>
    {
    }

    public abstract partial class SceneEntityProxy<T> : MonoBehaviour, IEntity where T : SceneEntity
    {
        [SerializeField]
        public T source;

        public int InstanceId
        {
            get { return source.InstanceId; }
        }

        public string Name
        {
            get => source.Name;
            set => source.Name = value;
        }

        private void Reset()
        {
            this.source = this.GetComponentInParent<T>();
        }

        public void Clear()
        {
            source.Clear();
        }

        private bool Equals(SceneEntityProxy<T> other)
        {
            return Equals(source, other.source);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is SceneEntityProxy<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return this.source.GetHashCode();
        }
    }
}