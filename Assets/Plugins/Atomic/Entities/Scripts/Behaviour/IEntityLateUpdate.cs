namespace Atomic.Entities
{
    public interface IEntityLateUpdate : IEntityBehaviour
    {
        void OnLateUpdate(in IEntity entity, in float deltaTime);
    }
    
    public interface IEntityLateUpdate<in T> : IEntityLateUpdate where T : IEntity
    {
        void IEntityLateUpdate.OnLateUpdate(in IEntity entity, in float deltaTime) => 
            this.OnLateUpdate((T) entity, in deltaTime);
        
        void OnLateUpdate(T entity, in float deltaTime);
    }
}