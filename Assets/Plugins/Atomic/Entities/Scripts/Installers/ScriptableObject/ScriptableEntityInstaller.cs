using UnityEngine;

namespace Atomic.Entities
{
    public abstract class ScriptableEntityInstaller : ScriptableObject, IEntityInstaller
    {
        public abstract void Install(IEntity entity);
    }
    
    public abstract class ScriptableEntityInstaller<T> : ScriptableEntityInstaller where T : class, IEntity
    {
        public sealed override void Install(IEntity entity) => this.Install((T) entity);
        protected abstract void Install(T entity);
    }
}