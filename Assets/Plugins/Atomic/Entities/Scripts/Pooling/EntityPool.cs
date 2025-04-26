using System.Collections.Generic;

namespace Atomic.Entities
{
    public abstract class EntityPool : IEntityPool
    {
        private readonly Queue<IEntity> _queue = new();
        
        public void Init(int count)
        {
            for (int i = 0; i < count; i++)
                _queue.Enqueue(this.Create());
        }

        public void Clear()
        {
            foreach (IEntity entity in _queue)
                this.Destroy(entity);

            _queue.Clear();
        }

        public IEntity Rent()
        {
            if (!_queue.TryDequeue(out IEntity entity))
                entity = this.Create();

            this.OnRent(entity);
            return entity;
        }

        public void Return(IEntity entity)
        {
            if (!_queue.Contains(entity))
            {
                this.OnReturn(entity);
                _queue.Enqueue(entity);
            }
        }
        
        protected abstract IEntity Create();
        
        protected abstract void Destroy(IEntity entity);

        protected virtual void OnRent(IEntity entity)
        {
        }

        protected virtual void OnReturn(IEntity entity)
        {
        }
    }
}