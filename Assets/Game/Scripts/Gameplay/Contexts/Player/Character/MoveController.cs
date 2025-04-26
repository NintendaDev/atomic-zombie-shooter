using Atomic.Contexts;
using Atomic.Entities;
using Game.Gameplay.Entity;
using Modules.Common;

namespace Game.Gameplay.Contexts.Player
{
    public sealed class MoveController : IContextInit<IPlayerContext>, IContextFixedUpdate
    {
        private Joystick _joystick;
        private IEntity _character;

        public void Init(IPlayerContext context)
        {
            _character = context.GetCharacter();
            _joystick = context.GetMoveJoystick();
        }

        public void OnFixedUpdate(IContext context, float deltaTime)
        {
            _character.GetMoveDirection().Value = JoystickUseCase.GetDirection(_joystick);
        }
    }
}