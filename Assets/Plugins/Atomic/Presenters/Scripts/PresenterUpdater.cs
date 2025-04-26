using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Atomic.Presenters
{
    internal sealed class PresenterUpdater : MonoBehaviour
    {
        private static PresenterUpdater _instance;
        private static bool _created;

        private readonly List<IPresenterUpdate> _updates = new();
        private readonly List<IPresenterFixedUpdate> _fixedUpdates = new();
        private readonly List<IPresenterLateUpdate> _lateUpdates = new();

        private readonly List<IPresenterUpdate> _updateCache = new();
        private readonly List<IPresenterFixedUpdate> _fixedUpdateCache = new();
        private readonly List<IPresenterLateUpdate> _lateUpdateCache = new();

        private static PresenterUpdater Instance
        {
            get
            {
                if (_instance != null || _created) 
                    return _instance;
                
                GameObject go = new GameObject(nameof(PresenterUpdater));
                DontDestroyOnLoad(go);
                
                _instance = go.AddComponent<PresenterUpdater>();
                _created = true;
                return _instance;
            }
        }

        public static void AddPresenter(IPresenter presenter)
        {
            PresenterUpdater instance = Instance; 
            if (presenter is IPresenterUpdate update) instance._updates.Add(update);
            if (presenter is IPresenterFixedUpdate fixedUpdate) instance._fixedUpdates.Add(fixedUpdate);
            if (presenter is IPresenterLateUpdate lateUpdate) instance._lateUpdates.Add(lateUpdate);
        }

        public static void DelPresenter(IPresenter presenter)
        {
            PresenterUpdater instance = Instance;
            if (presenter is IPresenterUpdate update) instance._updates.Remove(update);
            if (presenter is IPresenterFixedUpdate fixedUpdate) instance._fixedUpdates.Remove(fixedUpdate);
            if (presenter is IPresenterLateUpdate lateUpdate) instance._lateUpdates.Remove(lateUpdate);
        }

        private void Update()
        {
            int count = _updates.Count;
            if (count == 0)
                return;

            _updateCache.Clear();
            _updateCache.AddRange(_updates);

            float deltaTime = Time.deltaTime;

            for (int i = 0; i < count; i++) 
                _updateCache[i].OnUpdate(deltaTime);
        }

        private void FixedUpdate()
        {
            int count = _fixedUpdates.Count;
            if (count == 0)
                return;

            _fixedUpdateCache.Clear();
            _fixedUpdateCache.AddRange(_fixedUpdates);

            float deltaTime = Time.fixedDeltaTime;

            for (int i = 0; i < count; i++) 
                _fixedUpdateCache[i].OnFixedUpdate(deltaTime);
        }
        
        private void LateUpdate()
        {
            int count = _lateUpdates.Count;
            if (count == 0)
                return;

            _lateUpdateCache.Clear();
            _lateUpdateCache.AddRange(_lateUpdates);

            float deltaTime = Time.deltaTime;
            for (int i = 0; i < count; i++) 
                _lateUpdateCache[i].OnLateUpdate(deltaTime);
        }
        
        
#if UNITY_EDITOR
        [InitializeOnEnterPlayMode]
        private static void OnEnterPlayMode()
        {
            _created = false;
        }
#endif
    }
}