using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;
using Game.Gameplay.Projectiles;
using UnityEngine;

namespace Game.Gameplay.Weapons
{
    public static class ShootUseCase
    {
        public static void ShootBullet(in IGameContext gameContext, in Transform launchPoint, in BulletArgs args)
        {
            PrefabEntityPool pool = gameContext.GetEntityPool();
            
            SceneEntity projectile = pool.Rent(args.Prefab, launchPoint.position, 
                launchPoint.rotation.MakeSpreadRotation(args.SpreadDegree));
            
            IProjectileEntity projectileEntity = projectile as IProjectileEntity;
            projectileEntity.GetLifeTimer().Reset();
            
            projectile.GetRigidbody().velocity = launchPoint.forward * projectile.GetMoveSpeed().Value;
        }
        
        public static void DestroyBullet(in IGameContext gameContext, in IEntity projectile)
        {
            PrefabEntityPool pool = gameContext.GetEntityPool();
            pool.Return(projectile);
        }
    }
}