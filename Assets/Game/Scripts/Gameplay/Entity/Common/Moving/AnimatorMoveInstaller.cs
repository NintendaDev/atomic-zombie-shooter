using System;
using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    [Serializable]
    public sealed class AnimatorMoveInstaller : MoveInstaller
    {
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            entity.AddBehaviour<AnimatorMoveBehaviour>();
        }
    }
}