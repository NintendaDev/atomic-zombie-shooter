using Atomic.Elements;
using UnityEngine;
using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Items
{
    public sealed class AmmoItemInstaller : SceneEntityInstaller
    {
        [SerializeField] private int _ammoSize = 10;
        [SerializeField] private TriggerEventReceiver _triggerEventReceiver;
        
        public override void Install(IEntity entity)
        {
            IGameContext gameContext = GameContext.Instance;
            
            entity.AddTriggerEventReceiver(_triggerEventReceiver);
            
            entity.AddIsUsedItem(new BaseVariable<bool>());
            entity.AddItemTakeEvent(new BaseEvent());
            entity.AddAmmoSize(new Const<int>(_ammoSize));

            entity.AddItemUseAction(new BaseAction(() =>
            {
                if (AmmoItemUseCase.TryAddAmmo(gameContext, entity) == false)
                    return;
                
                entity.GetItemTakeEvent().Invoke();
                entity.GetIsUsedItem().Value = true;
            }));
            
            entity.AddBehaviour<ItemTakeBehaviour>();
        }
    }
}