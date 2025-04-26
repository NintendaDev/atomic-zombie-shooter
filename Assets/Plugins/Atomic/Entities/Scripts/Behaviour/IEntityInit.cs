namespace Atomic.Entities
{
    public interface IEntityInit : IEntityBehaviour
    {
        void Init(in IEntity entity);
    }

    public interface IEntityInit<in T> : IEntityInit where T : IEntity
    {
        void IEntityInit.Init(in IEntity entity) => this.Init((T) entity);
        void Init(T entity);
    }
}