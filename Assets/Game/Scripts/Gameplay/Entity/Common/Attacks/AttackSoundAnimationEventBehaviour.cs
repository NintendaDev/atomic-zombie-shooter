using Atomic.Entities;
using Modules.Audio;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Common
{
    public sealed class AttackSoundAnimationEventBehaviour : IEntityInit, IEntityDispose
    {
        private readonly UniqueAudioRandomizer _audioRandomizer;
        private readonly string _attackAnimationEventName;
        private AnimationEventReceiver _animationReceiver;
        private IEntity _entity;

        public AttackSoundAnimationEventBehaviour(UniqueAudioRandomizer audioRandomizer, 
            string attackAnimationEventName)
        {
            _audioRandomizer = audioRandomizer;
            _attackAnimationEventName = attackAnimationEventName;
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
            if (animationEventName != _attackAnimationEventName)
                return;

            _entity.TryPlayRandomSound(_audioRandomizer);
        }
    }
}