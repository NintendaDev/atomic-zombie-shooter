using Atomic.Entities;
using Game.Animation;
using Game.Gameplay.Contexts.Game;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class BodyFallBloodBehaviour : IEntityInit, IEntityDispose
    {
        private readonly IGameContext _gameContext;
        private readonly SceneEntity _bloodEffectEntity;
        private readonly Transform _rootTransform;
        private AnimationEventReceiver _eventReceiver;
        private IEntity _character;

        public BodyFallBloodBehaviour(IGameContext gameContext, SceneEntity bloodEffectEntity, Transform rootTransform)
        {
            _gameContext = gameContext;
            _bloodEffectEntity = bloodEffectEntity;
            _rootTransform = rootTransform;
        }

        public void Init(in IEntity entity)
        {
            _eventReceiver = entity.GetAnimationEventReceiver();
            _character = entity;
            _eventReceiver.EventReceived += OnAnimEvent;
        }

        public void Dispose(in IEntity entity)
        {
            _eventReceiver.EventReceived -= OnAnimEvent;
        }

        private void OnAnimEvent(string message)
        {
            if (message != AnimatorParameters.BodyFallEventName)
                return;

            _character.CreateGroundBlood(_gameContext, _rootTransform, _bloodEffectEntity);
        }
    }
}