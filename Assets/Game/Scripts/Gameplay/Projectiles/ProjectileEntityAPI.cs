/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;
using Modules.Gameplay;
using Game.Gameplay.Projectiles;

namespace Game.Gameplay.Projectiles
{
	public static class ProjectileEntityAPI
	{
		///Tags
		public const int Projectile = 1940275645;


		///Values
		public const int LifeTimer = -865616360; // Cooldown
		public const int Damage = 375673178; // IValue<int>


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectileTag(this IProjectileEntity obj) => obj.HasTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddProjectileTag(this IProjectileEntity obj) => obj.AddTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectileTag(this IProjectileEntity obj) => obj.DelTag(Projectile);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetLifeTimer(this IProjectileEntity obj) => obj.GetValue<Cooldown>(LifeTimer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifeTimer(this IProjectileEntity obj, out Cooldown value) => obj.TryGetValue(LifeTimer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddLifeTimer(this IProjectileEntity obj, Cooldown value) => obj.AddValue(LifeTimer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifeTimer(this IProjectileEntity obj) => obj.HasValue(LifeTimer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifeTimer(this IProjectileEntity obj) => obj.DelValue(LifeTimer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifeTimer(this IProjectileEntity obj, Cooldown value) => obj.SetValue(LifeTimer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IProjectileEntity obj) => obj.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IProjectileEntity obj, out IValue<int> value) => obj.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamage(this IProjectileEntity obj, IValue<int> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IProjectileEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IProjectileEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IProjectileEntity obj, IValue<int> value) => obj.SetValue(Damage, value);
    }
}
