using Atomic.Entities;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Common
{
    public abstract class AnimationEventBehaviour : IEntityInit, IEntityDispose
    {
        private AnimationEventReceiver _animationReceiver;

        protected abstract string AnimationEventName { get; }

        public virtual void Init(in IEntity entity)
        {
            _animationReceiver = entity.GetAnimationEventReceiver();
            _animationReceiver.EventReceived += OnAnimationEvent;
        }

        public virtual void Dispose(in IEntity entity)
        {
            _animationReceiver.EventReceived -= OnAnimationEvent;
        }

        protected abstract void OnAnimationEvent(string eventName);
    }
}