using System.ComponentModel.DataAnnotations;
using Atomic.Elements;
using UnityEngine;
using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Items
{
    public sealed class HealthItemInstaller : SceneEntityInstaller
    {
        [SerializeField] private int _healSize = 3;
        [SerializeField, Required] private TriggerEventReceiver _triggerEventReceiver;
        
        public override void Install(IEntity entity)
        {
            IGameContext gameContext = GameContext.Instance;
            
            entity.AddTriggerEventReceiver(_triggerEventReceiver);
            
            entity.AddIsUsedItem(new BaseVariable<bool>());
            entity.AddItemTakeEvent(new BaseEvent());
            entity.AddHealSize(new Const<int>(_healSize));

            entity.AddItemUseAction(new BaseAction(() =>
            {
                if (HealthUseCase.TryHeal(gameContext, entity) == false)
                    return;
                
                entity.GetItemTakeEvent().Invoke();
                entity.GetIsUsedItem().Value = true;
            }));
            
            entity.AddBehaviour<ItemTakeBehaviour>();
        }
    }
}