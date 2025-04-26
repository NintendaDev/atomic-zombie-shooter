using Atomic.Contexts;
using Atomic.Entities;
using Game.Gameplay.Entity;

namespace Game.Gameplay.Contexts.Player
{
    public sealed class FireController : IContextInit<IPlayerContext>, IContextUpdate<IPlayerContext>
    {
        private IEntity _character;

        public void Init(IPlayerContext context)
        {
            _character = context.GetCharacter();
        }

        public void OnUpdate(IPlayerContext context, float deltaTime)
        {
            if (context.GetFireCondition().Invoke() == false)
                return;
            
            _character.GetAttackAction().Invoke();
        }
    }
}