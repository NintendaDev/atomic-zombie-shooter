using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Contexts.Player;

namespace Game.Gameplay.Entity.Items
{
    public static class HealthUseCase
    {
        public static bool TryHeal(IGameContext context, IEntity healthEntity)
        {
            if (CanUse(context, healthEntity) == false)
                return false;
            
            IEntity character = context.GetPlayerContext().GetCharacter();
            character.GetHealth().Add(healthEntity.GetHealSize().Value);

            return true;
        }

        private static bool CanUse(IGameContext context, IEntity itemEntity)
        {
            bool isUsed = itemEntity.GetIsUsedItem().Value;

            if (isUsed)
                return false;
            
            IEntity character = context.GetPlayerContext().GetCharacter();
            bool isFulHealth = character.GetHealth().IsFull();
            
            return isFulHealth == false;
        }
    }
}