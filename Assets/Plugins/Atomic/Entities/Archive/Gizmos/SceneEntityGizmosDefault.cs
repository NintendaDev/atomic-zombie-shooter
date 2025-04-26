// #if ODIN_INSPECTOR
// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace Atomic.Entities
// {
//     [AddComponentMenu("Atomic/Entities/Entity Gizmos")]
//     [DisallowMultipleComponent]
//     public class SceneEntityGizmosDefault : SceneEntityGizmos
//     {
//         [Space]
//         [SerializeReference]
//         protected List<IEntityGizmos> gizmoses = new();
//
//         public override void OnGizmosDraw(in IEntity entity)
//         {
//             if (this.gizmoses == null || gizmoses.Count == 0)
//                 return;
//
//             for (int i = 0, count = this.gizmoses.Count; i < count; i++)
//             {
//                 try
//                 {
//                     IEntityGizmos gizmos = this.gizmoses[i];
//                     gizmos?.OnGizmosDraw(entity);
//                 }
//                 catch (Exception e)
//                 {
//                     Debug.LogWarning($"Ops: detected exception in gizmos: {e.Message}");
//                 }
//             }
//         }
//     }
// }
// #endif