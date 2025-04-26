using Atomic.Contexts;
using Game.Gameplay.Contexts.Game;
using UnityEngine;

namespace Game.Gameplay.Contexts.Player
{
    public sealed class PlayerContextInstaller : SceneContextInstaller<IPlayerContext>
    {
        [SerializeField] private CharacterSystemInstaller _characterSystemInstaller;
        [SerializeField] private PlayerInputInstaller _playerInputInstaller;
        
        protected override void Install(IPlayerContext context)
        {
            GameContext.Instance.AddPlayerContext(context);
            
            _playerInputInstaller.Install(context);
            _characterSystemInstaller.Install(context);
        }
    }
}