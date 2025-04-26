namespace Atomic.Entities
{
    public interface IEntityDispose
    {
        void Dispose(in IEntity entity);
    }
    
    public interface IEntityDispose<in T> : IEntityDispose where T : IEntity
    {
        void IEntityDispose.Dispose(in IEntity entity) => this.Dispose((T) entity);
        void Dispose(T entity);
    }
}