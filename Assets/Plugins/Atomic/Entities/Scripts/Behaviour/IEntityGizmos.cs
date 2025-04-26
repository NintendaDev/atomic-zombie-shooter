namespace Atomic.Entities
{
    public interface IEntityGizmos : IEntityBehaviour
    {
        void OnGizmosDraw(in IEntity entity);
    }

    public interface IEntityGizmos<in T> : IEntityGizmos where T : IEntity
    {
        void IEntityGizmos.OnGizmosDraw(in IEntity entity) => this.OnGizmosDraw((T) entity);
        void OnGizmosDraw(T entity);
    }
}