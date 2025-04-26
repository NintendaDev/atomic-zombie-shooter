using Game.Gameplay.Projectiles;

namespace Game.Gameplay.Weapons
{
    public struct BulletArgs
    {
        public BulletArgs(ProjectileEntity prefab, float spreadDegree)
        {
            Prefab = prefab;
            SpreadDegree = spreadDegree;
        }
        
        public ProjectileEntity Prefab;

        public float SpreadDegree;
    }
}