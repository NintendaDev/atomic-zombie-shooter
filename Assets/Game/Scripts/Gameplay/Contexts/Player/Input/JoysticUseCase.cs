using Modules.Common;
using UnityEngine;

namespace Game.Gameplay.Contexts.Player
{
    public static class JoystickUseCase
    {
        public static Vector3 GetDirection(this Joystick joystick, in IPlayerContext context)
        {
            if (IsActive(joystick, context) == false)
                return Vector3.zero;
            
            return GetDirection(joystick);
        }

        public static bool IsActive(this Joystick joystick, in IPlayerContext context) => 
            joystick.Direction.sqrMagnitude > context.GetJoystickActiveThreshold().Value;

        public static  Vector3 GetDirection(in Joystick joystick) => 
            new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
}