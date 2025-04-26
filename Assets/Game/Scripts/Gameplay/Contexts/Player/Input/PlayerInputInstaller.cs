using System;
using Atomic.Contexts;
using Atomic.Elements;
using Modules.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Contexts.Player
{
    [Serializable]
    public sealed class PlayerInputInstaller : IContextInstaller<IPlayerContext>
    {
        [SerializeField, Required] private Joystick _moveJoystick;
        [SerializeField, Required] private Joystick _fireJoystick;
        [SerializeField, MinValue(0)] private float _joystickActiveThreshold;
        [SerializeField, MinValue(0)] private float _firstAttackDelay = 1f;
        
        public void Install(IPlayerContext context)
        {
            context.AddFireJoystick(_fireJoystick);
            context.AddMoveJoystick(_moveJoystick);
            context.AddFirstAttackDelay(new Const<float>(_firstAttackDelay));
            context.AddJoystickActiveThreshold(new Const<float>(_joystickActiveThreshold));
        }
    }
}