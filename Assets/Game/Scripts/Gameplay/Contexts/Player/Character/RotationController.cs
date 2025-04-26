using Atomic.Contexts;
using Atomic.Entities;
using Game.Gameplay.Entity;
using Modules.Common;

namespace Game.Gameplay.Contexts.Player
{
    public sealed class RotationController : IContextInit<IPlayerContext>, IContextFixedUpdate<IPlayerContext>
    {
        private IEntity _character;
        private Joystick _fireJoystick;
        private Joystick _moveJoystick;

        public void Init(IPlayerContext context)
        {
            _fireJoystick = context.GetFireJoystick();
            _moveJoystick = context.GetMoveJoystick();
            _character = context.GetCharacter();
        }

        public void OnFixedUpdate(IPlayerContext context, float deltaTime)
        {
            if (_fireJoystick.IsActive(context))
                _character.GetRotateDirection().Value = _fireJoystick.GetDirection(context);
            else
                _character.GetRotateDirection().Value = _moveJoystick.GetDirection(context);
        }
    }
}