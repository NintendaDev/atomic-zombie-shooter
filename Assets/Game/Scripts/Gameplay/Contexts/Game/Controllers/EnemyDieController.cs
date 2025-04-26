using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;

namespace Game.Gameplay.Contexts.Game
{
    public sealed class EnemyDieController : IContextInit<IGameContext>, IContextDispose
    {
        private IReactiveList<IEntity> _enemies;
        private IGameContext _context;

        public void Init(IGameContext context)
        {
            _context = context;
            _enemies = context.GetEnemies();

            foreach (IEntity entity in _enemies)
                entity.GetDeathEvent().Subscribe(OnEnemyDeath);

            _enemies.OnItemInserted += OnEnemyInserted;
            _enemies.OnItemDeleted += OnEnemyDeleted;
        }

        public void Dispose(IContext context)
        {
            _enemies.OnItemInserted -= OnEnemyInserted;
            
            foreach (IEntity entity in _enemies)
                entity.GetDeathEvent().Unsubscribe(OnEnemyDeath);
        }

        private void OnEnemyDeath(TakeDamageArgs _)
        {
            ScoreUseCase.IncreaseScore(_context);
        }

        private void OnEnemyInserted(int index, IEntity enemy) =>
            enemy.GetDeathEvent().Subscribe(OnEnemyDeath);

        private void OnEnemyDeleted(int index, IEntity enemy) =>
            enemy.GetDeathEvent().Unsubscribe(OnEnemyDeath);
    }
}