using Atomic.Contexts;

namespace Game.Gameplay.Contexts.Player
{
    public interface IPlayerContext : IContext
    {
    }
    
    public sealed class PlayerContext : SceneContext, IPlayerContext
    {
    }
}