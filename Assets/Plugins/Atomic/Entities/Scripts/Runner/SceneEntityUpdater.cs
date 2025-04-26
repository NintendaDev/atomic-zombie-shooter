using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Atomic.Entities
{
    internal sealed class SceneEntityUpdater : MonoBehaviour
    {
        private static SceneEntityUpdater _instance;
        private static bool installed;

        private readonly HashSet<IEntity> entities = new();
        private readonly List<IEntity> _entities = new();
        
        private static SceneEntityUpdater instance
        {
            get
            {
                if (_instance == null && !installed)
                {
                    GameObject go = new GameObject(nameof(SceneEntityUpdater));
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<SceneEntityUpdater>();
                    installed = true;
                }

                return _instance;
            }
        }

        public static void AddEntity(IEntity entity)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                instance.entities.Add(entity);
            }
#else
            instance.entities.Add(entity);
#endif
        }

        public static void DelEntity(IEntity entity)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                instance.entities.Remove(entity);
            }
#else
            instance.entities.Remove(entity);
#endif
        }

        #region Unity

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            int count = this.entities.Count;
            if (count == 0)
            {
                return;
            }

            _entities.Clear();
            _entities.AddRange(this.entities);

            for (int i = 0; i < count; i++)
            {
                IEntity entity = _entities[i];
                entity.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            float deltaTime = Time.fixedDeltaTime;
            int count = this.entities.Count;
            if (count == 0)
            {
                return;
            }

            _entities.Clear();
            _entities.AddRange(this.entities);

            for (int i = 0; i < count; i++)
            {
                IEntity entity = _entities[i];
                entity.OnFixedUpdate(deltaTime);
            }
        }


        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            int count = this.entities.Count;
            if (count == 0)
            {
                return;
            }

            _entities.Clear();
            _entities.AddRange(this.entities);

            for (int i = 0; i < count; i++)
            {
                IEntity entity = _entities[i];
                entity.OnLateUpdate(deltaTime);
            }
        }

        #endregion
        
#if UNITY_EDITOR
        [InitializeOnEnterPlayMode]
        private static void OnEnterPlayMode()
        {
            installed = false;
        }
#endif
    }
}