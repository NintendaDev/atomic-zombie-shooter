// using UnityEngine;
//
// namespace Atomic.Entities
// {
//     public abstract class SceneEntityGizmos : MonoBehaviour, IEntityGizmos
//     {
//         public abstract void OnGizmosDraw(in IEntity entity);
//     }
//
//     public abstract class SceneEntityGizmos<T> : SceneEntityGizmos where T : SceneEntity
//     {
//         public override void OnGizmosDraw(in IEntity entity) => this.OnGizmosDraw((T) entity);
//         protected abstract void OnGizmosDraw(T entity);
//     }
// }
//
//
