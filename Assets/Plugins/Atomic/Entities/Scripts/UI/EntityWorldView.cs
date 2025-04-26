using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Entities.UI
{
    [AddComponentMenu("Atomic/Entities/Entity World View")]
    [DisallowMultipleComponent]
    public class EntityWorldView : MonoBehaviour
    {
        private static readonly DefaultBinder s_defaultBinder = new();

        private const string VIEWPORT_NAME = "Viewport";
        private const string POOL_NAME = "Pool";

        private readonly Dictionary<IEntity, EntityView> _activeViews = new();
        private Transform _viewport;
        private EntityPresenterPool _viewPool;

        private IEntityWorld _world;
        private IBinder _binder;
        private bool _awaked;

        private void Awake()
        {
            if (!_awaked)
            {
                _viewport = this.CreateContainer(VIEWPORT_NAME, true);
                _viewPool = new EntityPresenterPool(this.CreateContainer(POOL_NAME, false));
            }
        }

        public void Init(IEntityWorld world, IBinder binder = null)
        {
            this.Awake();

            binder ??= s_defaultBinder;
            _binder = binder;
            
            _world = world;
            _world.OnEntityAdded += this.SpawnPresenter;
            _world.OnEntityDeleted += this.UnspawnPresenter;

            foreach (IEntity entity in _world.Entities)
                this.SpawnPresenter(entity);
        }

        public void Dispose()
        {
            foreach (IEntity entity in _world.Entities)
                this.UnspawnPresenter(entity);

            _world.OnEntityAdded -= this.SpawnPresenter;
            _world.OnEntityDeleted -= this.UnspawnPresenter;
            _world = null;
            
            _viewPool.Clear();
        }

        private void SpawnPresenter(IEntity entity)
        {
            string name = _binder.GetTypeName(entity);
            EntityView view = _viewPool.Rent(name);
            view.transform.parent = _viewport;
            view.Show(entity);
            _activeViews.Add(entity, view);
        }

        private void UnspawnPresenter(IEntity entity)
        {
            if (!_activeViews.Remove(entity, out EntityView presenter))
                return;

            presenter.Hide();
            string name = _binder.GetTypeName(entity);
            _viewPool.Return(name, presenter);
        }

        private Transform CreateContainer(string name, bool active)
        {
            GameObject go = new GameObject(name);
            go.SetActive(active);
            Transform result = go.transform;
            result.parent = this.transform;
            return result;
        }

        public interface IBinder
        {
            string GetTypeName(IEntity entity);
            string GetTypeName(EntityView view);
        }
        
        private sealed class DefaultBinder : IBinder
        {
            public string GetTypeName(IEntity entity) => entity.Name;
            public string GetTypeName(EntityView view) => view.name;
        }
        
        private sealed class EntityPresenterPool
        {
            private readonly Dictionary<string, Queue<EntityView>> _pools;
            private readonly Dictionary<string, EntityView> _prefabs;
            private readonly Transform _container;

            public EntityPresenterPool(Transform container)
            {
                _container = container;
                _pools = new Dictionary<string, Queue<EntityView>>();
                _prefabs = new Dictionary<string, EntityView>();
            }

            public EntityView Rent(string name)
            {
                Queue<EntityView> pool = this.GetPool(name);
                if (pool.TryDequeue(out EntityView presenter))
                    return presenter;

                EntityView prefab = _prefabs[name];
                return Instantiate(prefab, _container);
            }
            
            public void AddPrefabs(IEnumerable<KeyValuePair<string, EntityView>> prefabs)
            {
                foreach ((string name, EntityView prefab) in prefabs) 
                    _prefabs.Add(name, prefab);
            }

            public void AddPrefab(string name, EntityView prefab)
            {
                _prefabs.Add(name, prefab);
            }
            
            public void DelPrefab(string name)
            {
                _prefabs.Remove(name);
            }

            public void Return(string name, EntityView view)
            {
                Queue<EntityView> pool = this.GetPool(name);
                pool.Enqueue(view);
                view.transform.parent = _container;
            }

            public void Clear()
            {
                foreach (Queue<EntityView> pool in _pools.Values)
                {
                    foreach (EntityView view in pool)
                        Destroy(view.gameObject);
                    
                    pool.Clear();
                }

                _pools.Clear();
            }

            private Queue<EntityView> GetPool(string name)
            {
                if (_pools.TryGetValue(name, out Queue<EntityView> pool))
                    return pool;

                pool = new Queue<EntityView>();
                _pools.Add(name, pool);
                return pool;
            }
        }
    }
}