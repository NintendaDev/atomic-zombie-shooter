using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class RaycastUseCase
    {
        public static bool TryRaycastGround(this IEntity entity, Transform raycastPoint, out Vector3 point)
        {
            return TryRaycast(raycastPoint.position, entity.GetGroundLayerMask(), out point);
        }

        public static bool TryRaycast(in Vector3 position, LayerMask layerMask, out Vector3 point)
        {
            point = Vector3.zero;
            
            if (Physics.Raycast(position, Vector3.down, out var hit, 100f, 
                    layerMask) == false)
            {
                return false;
            }
            
            point = hit.point;

            return true;
        }

        public static bool TryRacycastEntities(this Transform point, in float radius, out List<IEntity> entities)
        {
            entities = new List<IEntity>();
            
            Collider[] colliders = Physics.OverlapSphere(point.position, radius);

            foreach (Collider collider in colliders)
            {
                if (collider.transform.TryGetComponent(out IEntity entity))
                    entities.Add(entity);
            }

            return entities.Count > 0;
        }

        public static bool TryRaycastPlayer(this Transform point, in float radius, out IEntity player)
        {
            player = null;
            
            if (TryRacycastEntities(point, radius, out List<IEntity> entities) == false)
                return false;

            foreach (IEntity entity in entities)
            {
                if (entity.HasPlayerTag())
                {
                    player = entity;
                    
                    return true;
                }
            }

            return false;
        }
    }
}