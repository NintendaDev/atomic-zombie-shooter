using System;
using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Contexts.Player
{
    [Serializable]
    public sealed class CharacterSystemInstaller : IContextInstaller<IPlayerContext>
    {
        [SerializeField, Required] private SceneEntity _character;
        
        public void Install(IPlayerContext context)
        {
            context.AddCharacter(_character);
            context.AddController<MoveController>();
            context.AddController<RotationController>();
            
            context.AddFirstFireCooldown(new Cooldown(context.GetFirstAttackDelay().Value));
            context.AddFireCondition(new AndExpression(context.GetFirstFireCooldown().IsExpired,
                () => context.GetFireJoystick().IsActive(context)));
            
            context.AddController<FireController>();
            
            context.WhenUpdate(deltaTime =>
            {
                if (context.GetFireJoystick().IsActive(context) == false)
                    context.GetFirstFireCooldown().Reset();
                
                context.GetFirstFireCooldown().Tick(deltaTime);
            });
        }
    }
}