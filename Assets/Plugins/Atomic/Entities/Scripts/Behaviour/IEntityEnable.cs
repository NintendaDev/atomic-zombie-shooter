namespace Atomic.Entities
{
    public interface IEntityEnable : IEntityBehaviour
    {
        void Enable(in IEntity entity);
    }

    public interface IEntityEnable<in T> : IEntityEnable where T : IEntity
    {
        void IEntityEnable.Enable(in IEntity entity) => this.Enable((T) entity);
        void Enable(T entity);
    }
}