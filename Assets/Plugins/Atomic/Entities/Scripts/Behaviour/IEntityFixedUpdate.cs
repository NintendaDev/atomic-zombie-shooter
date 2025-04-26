namespace Atomic.Entities
{
    public interface IEntityFixedUpdate : IEntityBehaviour
    {
        void OnFixedUpdate(in IEntity entity, in float deltaTime);
    }

    public interface IEntityFixedUpdate<in T> : IEntityFixedUpdate where T : IEntity
    {
        void IEntityFixedUpdate.OnFixedUpdate(in IEntity entity, in float deltaTime) =>
            this.OnFixedUpdate((T) entity, in deltaTime);
        
        void OnFixedUpdate(T entity, in float deltaTime);
    }
}