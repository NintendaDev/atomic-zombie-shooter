using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        private static readonly Dictionary<IEntity, SceneEntity> s_entities = new();

        public static SceneEntity Create(
            string name = null,
            IEnumerable<int> tags = null,
            IReadOnlyDictionary<int, object> values = null,
            IEnumerable<IEntityBehaviour> behaviours = null
        )
        {
            GameObject gameObject = new GameObject(name);
            SceneEntity sceneEntity = gameObject.AddComponent<SceneEntity>();
            sceneEntity.Name = name;

            sceneEntity.AddTags(tags);
            sceneEntity.AddValues(values);
            sceneEntity.AddBehaviours(behaviours);

            sceneEntity.Install();
            return sceneEntity;
        }

        public static SceneEntity Create(SceneEntity prefab, Transform parent)
        {
            SceneEntity entity = Instantiate(prefab, parent);
            entity.Install();
            return entity;
        }

        public static SceneEntity Create(
            SceneEntity prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent = null
        )
        {
            SceneEntity entity = Instantiate(prefab, position, rotation, parent);
            entity.Install();
            return entity;
        }

        public static void Destroy(IEntity entity, float t = 0)
        {
            if (TryCast(entity, out SceneEntity sceneEntity))
                Destroy(sceneEntity.gameObject, t);
        }

        public static SceneEntity Cast(IEntity entity)
        {
            if (entity == null)
                return null;

            if (entity is SceneEntity sceneEntity)
                return sceneEntity;

            if (entity is SceneEntityProxy proxy)
                return proxy.source;

            s_entities.TryGetValue(entity, out sceneEntity);
            return sceneEntity;
        }

        public static bool TryCast(IEntity entity, out SceneEntity result)
        {
            if (entity == null)
            {
                result = null;
                return false;
            }

            if (entity is SceneEntity sceneEntity)
            {
                result = sceneEntity;
                return true;
            }

            if (entity is SceneEntityProxy proxy)
            {
                result = proxy.source;
                return true;
            }

            return s_entities.TryGetValue(entity, out result);
        }

#if UNITY_EDITOR
        [InitializeOnEnterPlayMode]
        private static void OnEnterPlayMode()
        {
            s_entities.Clear();
        }
#endif
    }
}