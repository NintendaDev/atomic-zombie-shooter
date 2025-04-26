using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    public struct TakeDamageArgs
    {
        public TakeDamageArgs(IEntity source, int damage)
        {
            Source = source;
            Damage = damage;
        }

        public IEntity Source;

        public int Damage;
    }
}