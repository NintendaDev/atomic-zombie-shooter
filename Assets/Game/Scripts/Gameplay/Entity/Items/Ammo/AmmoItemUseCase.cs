using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Contexts.Player;
using Game.Gameplay.Entity.Common;

namespace Game.Gameplay.Entity.Items
{
    public static class AmmoItemUseCase
    {
        public static bool TryAddAmmo(in IGameContext context, in IEntity ammoItemEntity)
        {
            if (CanUse(context, ammoItemEntity) == false)
                return false;
            
            IEntity character = context.GetPlayerContext().GetCharacter();
                
            return AmmoUseCase.TryAddAmmo(character, ammoItemEntity.GetAmmoSize().Value);
        }

        private static bool CanUse(in IGameContext context, in IEntity itemEntity)
        {
            bool isUsed = itemEntity.GetIsUsedItem().Value;

            if (isUsed)
                return false;

            IEntity character = context.GetPlayerContext().GetCharacter();
            bool isExistsWeapon = character.IsExistsWeapon(out _);
            
            return isExistsWeapon;
        }
    }
}