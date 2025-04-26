#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        [Header("Gizmos")]
        [SerializeField]
        private bool _onlySelectedGizmos;

        [SerializeField]
        private bool _onlyEditModeGizmos;

        private void OnDrawGizmos()
        {
            if (!_onlySelectedGizmos)
                this.OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            if (EditorApplication.isPlaying && _onlyEditModeGizmos)
                return;

            IReadOnlyCollection<IEntityBehaviour> behaviours = this.entity.Behaviours;
            if (behaviours.Count == 0)
                return;

            try
            {
                foreach (IEntityBehaviour behaviour in behaviours)
                {
                    if (behaviour is IEntityGizmos gizmos) 
                        gizmos.OnGizmosDraw(this.entity);
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Ops: detected exception in gizmos: {e.Message}");
            }
        }
    }
}
#endif