namespace Atomic.Entities
{
    public interface IEntityUpdate : IEntityBehaviour
    {
        void OnUpdate(in IEntity entity, in float deltaTime);
    }

    public interface IEntityUpdate<in T> : IEntityUpdate where T : IEntity
    {
        void IEntityUpdate.OnUpdate(in IEntity entity, in float deltaTime) =>
            this.OnUpdate((T) entity, in deltaTime);
        
        void OnUpdate(T entity, in float deltaTime);
    }
}