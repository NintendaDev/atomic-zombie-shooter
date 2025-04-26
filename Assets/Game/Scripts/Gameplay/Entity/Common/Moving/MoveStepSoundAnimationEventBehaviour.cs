using Atomic.Entities;
using Modules.Audio;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Common
{
    public sealed class MoveStepSoundAnimationEventBehaviour : IEntityInit, IEntityDispose
    {
        private readonly UniqueAudioRandomizer _audioRandomizer;
        private readonly string _moveStepAnimationEventName;
        private AnimationEventReceiver _animationReceiver;
        private IEntity _entity;

        public MoveStepSoundAnimationEventBehaviour(UniqueAudioRandomizer audioRandomizer, 
            string moveStepAnimationEventName)
        {
            _audioRandomizer = audioRandomizer;
            _moveStepAnimationEventName = moveStepAnimationEventName;
        }
        
        public void Init(in IEntity entity)
        {
            _entity = entity;
            _animationReceiver = entity.GetAnimationEventReceiver();
            _animationReceiver.EventReceived += OnAnimationEvent;
        }

        public void Dispose(in IEntity entity)
        {
            _animationReceiver.EventReceived -= OnAnimationEvent;
        }

        private void OnAnimationEvent(string animationEventName)
        {
            if (_moveStepAnimationEventName != animationEventName)
                return;
            
            _entity.TryPlayRandomSound(_audioRandomizer);
        }
    }
}