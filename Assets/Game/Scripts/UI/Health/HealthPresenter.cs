using Atomic.Entities;
using Atomic.Presenters;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Contexts.Player;
using Game.Gameplay.Entity;
using Modules.Gameplay;

namespace Game.UI
{
    public abstract class HealthPresenter : Presenter
    {
        protected Health Health { get; private set; }

        protected override void OnInit()
        {
            base.OnInit();
            
            IEntity character = GameContext.Instance.GetPlayerContext().GetCharacter();
            Health = character.GetHealth();
            
            Health.StateChanged += OnHealthChange;
        }

        protected override void OnDispose()
        {
            Health.StateChanged -= OnHealthChange;
        }

        protected abstract void OnHealthChange();
    }
}