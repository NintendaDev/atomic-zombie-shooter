using System;
using System.Collections.Generic;

namespace Atomic.Entities
{
    public class EntityPoolMap<TKey>
    {
        private readonly Dictionary<TKey, IEntityPool> _pools = new();

        public void AddPool(TKey key, IEntityPool pool, int initialCount = 0)
        {
            if (!_pools.TryAdd(key, pool))
                throw new Exception($"Pool with {key} is already added!");

            pool.Init(initialCount);
        }

        public void RemovePool(TKey key)
        {
            if (_pools.Remove(key, out IEntityPool pool)) 
                pool.Clear();
        }

        public IEntity Rent(TKey key)
        {
            if (!_pools.TryGetValue(key, out IEntityPool pool))
                throw new KeyNotFoundException($"The given pool with {key} is not present!");

            return pool.Rent();
        }

        public void Return(TKey key, IEntity entity)
        {
            if (!_pools.TryGetValue(key, out IEntityPool pool))
                throw new KeyNotFoundException($"The given pool with {key} is not present!");

            pool.Return(entity);
        }
    }
}