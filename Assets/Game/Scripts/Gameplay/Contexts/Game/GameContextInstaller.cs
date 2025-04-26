using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Contexts.Game
{
    public sealed class GameContextInstaller : SceneContextInstaller<GameContext>
    {
        [SerializeField, MinValue(1)] private int _killReward = 1;
        [SerializeField, Required] private Transform _poolTransform;
        
        protected override void Install(GameContext context)
        {
            context.AddEntityPool(new PrefabEntityPool(_poolTransform));
            context.AddEnemies(new ReactiveList<IEntity>());
            InstallScoreController(context);
        }

        private void InstallScoreController(GameContext context)
        {
            context.AddScore(new ReactiveInt());
            context.AddKillReward(new Const<int>(_killReward));
            context.AddController<EnemyDieController>();
        }
    }
}