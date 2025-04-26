using System.Collections.Generic;

namespace Atomic.Entities
{
    public class EntityFactory : EntityFactory<string>
    {
        public EntityFactory()
        {
        }

        public EntityFactory(IEnumerable<KeyValuePair<string, IEntityInstaller>> installers) : base(installers)
        {
        }

        public EntityFactory(params KeyValuePair<string, IEntityInstaller>[] installers) : base(installers)
        {
        }
    }

    public class EntityFactory<TKey>
    {
        private readonly Dictionary<TKey, IEntityInstaller> _installers;

        public EntityFactory()
        {
            _installers = new Dictionary<TKey, IEntityInstaller>();
        }

        public EntityFactory(IEnumerable<KeyValuePair<TKey, IEntityInstaller>> installers)
        {
            _installers = new Dictionary<TKey, IEntityInstaller>(installers);
        }

        public EntityFactory(params KeyValuePair<TKey, IEntityInstaller>[] installers)
        {
            _installers = new Dictionary<TKey, IEntityInstaller>(installers);
        }

        public EntityFactory<TKey> Bind(TKey key, IEntityInstaller installer)
        {
            _installers.Add(key, installer);
            return this;
        }

        public EntityFactory<TKey> Unbind(TKey key)
        {
            _installers.Remove(key);
            return this;
        }

        public IEntity Create(TKey key)
        {
            if (!_installers.TryGetValue(key, out IEntityInstaller installer))
                throw new KeyNotFoundException($"Can't create entity with key: {key}");

            IEntity entity = new Entity();
            installer.Install(entity);
            return entity;
        }
    }
}