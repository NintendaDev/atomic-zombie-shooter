using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class BodyFallSoundAnimationEventBehaviour : IEntityInit, IEntityDispose
    {
        private readonly AudioClip _audioClip;
        private readonly string _bodyFallAnimationEventName;
        private IEntity _entity;
        private AnimationEventReceiver _animationReceiver;

        public BodyFallSoundAnimationEventBehaviour(AudioClip audioClip, string bodyFallAnimationEventName)
        {
            _audioClip = audioClip;
            _bodyFallAnimationEventName = bodyFallAnimationEventName;
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
            if (_bodyFallAnimationEventName != animationEventName)
                return;
            
            _entity.TryPlaySound(_audioClip);
        }
    }
}