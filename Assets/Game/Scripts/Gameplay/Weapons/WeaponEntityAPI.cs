/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;
using Modules.Gameplay;
using Game.Gameplay.Weapons;

namespace Game.Gameplay.Weapons
{
	public static class WeaponEntityAPI
	{
		///Tags
		public const int Projectile = 1940275645;
		public const int Melee = 237393061;


		///Values
		public const int Ammo = 1337839892; // Ammo
		public const int AttackSounds = -1161121369; // AudioClip[]
		public const int Damage = 375673178; // IValue<int>
		public const int DamageRadius = 945363216; // IValue<float>
		public const int BulletArgs = -878367630; // BulletArgs


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectileTag(this IWeaponEntity obj) => obj.HasTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddProjectileTag(this IWeaponEntity obj) => obj.AddTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectileTag(this IWeaponEntity obj) => obj.DelTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMeleeTag(this IWeaponEntity obj) => obj.HasTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMeleeTag(this IWeaponEntity obj) => obj.AddTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMeleeTag(this IWeaponEntity obj) => obj.DelTag(Melee);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Ammo GetAmmo(this IWeaponEntity obj) => obj.GetValue<Ammo>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IWeaponEntity obj, out Ammo value) => obj.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmo(this IWeaponEntity obj, Ammo value) => obj.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IWeaponEntity obj) => obj.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IWeaponEntity obj) => obj.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IWeaponEntity obj, Ammo value) => obj.SetValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioClip[] GetAttackSounds(this IWeaponEntity obj) => obj.GetValue<AudioClip[]>(AttackSounds);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackSounds(this IWeaponEntity obj, out AudioClip[] value) => obj.TryGetValue(AttackSounds, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackSounds(this IWeaponEntity obj, AudioClip[] value) => obj.AddValue(AttackSounds, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackSounds(this IWeaponEntity obj) => obj.HasValue(AttackSounds);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackSounds(this IWeaponEntity obj) => obj.DelValue(AttackSounds);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackSounds(this IWeaponEntity obj, AudioClip[] value) => obj.SetValue(AttackSounds, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IWeaponEntity obj) => obj.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IWeaponEntity obj, out IValue<int> value) => obj.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamage(this IWeaponEntity obj, IValue<int> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IWeaponEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IWeaponEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IWeaponEntity obj, IValue<int> value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetDamageRadius(this IWeaponEntity obj) => obj.GetValue<IValue<float>>(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamageRadius(this IWeaponEntity obj, out IValue<float> value) => obj.TryGetValue(DamageRadius, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageRadius(this IWeaponEntity obj, IValue<float> value) => obj.AddValue(DamageRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageRadius(this IWeaponEntity obj) => obj.HasValue(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageRadius(this IWeaponEntity obj) => obj.DelValue(DamageRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamageRadius(this IWeaponEntity obj, IValue<float> value) => obj.SetValue(DamageRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static BulletArgs GetBulletArgs(this IWeaponEntity obj) => obj.GetValue<BulletArgs>(BulletArgs);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletArgs(this IWeaponEntity obj, out BulletArgs value) => obj.TryGetValue(BulletArgs, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletArgs(this IWeaponEntity obj, BulletArgs value) => obj.AddValue(BulletArgs, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletArgs(this IWeaponEntity obj) => obj.HasValue(BulletArgs);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletArgs(this IWeaponEntity obj) => obj.DelValue(BulletArgs);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletArgs(this IWeaponEntity obj, BulletArgs value) => obj.SetValue(BulletArgs, value);
    }
}
