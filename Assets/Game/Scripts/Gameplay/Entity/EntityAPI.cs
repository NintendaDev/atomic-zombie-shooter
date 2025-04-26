/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Elements;
using Modules.Gameplay;
using Game.Gameplay;
using Game.Gameplay.Weapons;
using Game.Gameplay.Entity.Common;
using Game.Gameplay.Entity.Items;

namespace Game.Gameplay.Entity
{
	public static class EntityAPI
	{
		///Tags
		public const int Player = -1615495341;
		public const int Damageable = 563499515;
		public const int Movable = 198794611;
		public const int Projectile = 1940275645;
		public const int Melee = 237393061;
		public const int VisualEffect = 1947835116;


		///Values
		public const int Transform = -180157682; // Transform
		public const int Rigidbody = -2101481708; // Rigidbody
		public const int Animator = -1714818978; // Animator
		public const int AudioSource = 907064781; // AudioSource
		public const int Cooldown = 655707791; // Cooldown
		public const int Target = 1103309514; // IReactiveVariable<Transform>
		public const int AnimationEventReceiver = 1837262450; // AnimationEventReceiver
		public const int GroundLayerMask = -1161184439; // LayerMask
		public const int CollisionEventReceiver = 396602988; // CollisionEventReceiver
		public const int TriggerEventReceiver = -484936241; // TriggerEventReceiver
		public const int Health = -915003867; // Health
		public const int DeathEvent = -1096613677; // IReactiveVariable<TakeDamageArgs>
		public const int TakeDamageEvent = 1486057413; // IEvent<TakeDamageArgs>
		public const int HealEvent = 1978810784; // IReactiveVariable<int>
		public const int RotateDirection = -1044844011; // IReactiveVariable<Vector3>
		public const int RotateCondition = 1109699557; // IExpression<bool>
		public const int AngularSpeed = -1089183267; // IValue<float>
		public const int MoveDirection = -721923052; // IReactiveVariable<Vector3>
		public const int MoveCondition = 1466174948; // IExpression<bool>
		public const int MoveSpeed = 526065662; // IReactiveVariable<float>
		public const int CurrentWeapon = -205032771; // IReactiveVariable<IWeaponEntity>
		public const int AttackCondition = -1481262935; // IExpression<bool>
		public const int AttackAction = 203766724; // IAction
		public const int AttackEvent = -691201150; // IEvent
		public const int IsUsedItem = 581670464; // IVariable<bool>
		public const int ItemUseAction = 629935103; // IAction
		public const int ItemTakeEvent = -914344217; // IEvent
		public const int HealSize = -1358399608; // IValue<int>
		public const int AmmoSize = -1278568337; // IValue<int>
		public const int StartVisualEffectAction = 2088893103; // IAction
		public const int StopVisualEffectAction = 1076580458; // IAction


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerTag(this IEntity obj) => obj.HasTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerTag(this IEntity obj) => obj.AddTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerTag(this IEntity obj) => obj.DelTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity obj) => obj.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity obj) => obj.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity obj) => obj.DelTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMovableTag(this IEntity obj) => obj.HasTag(Movable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMovableTag(this IEntity obj) => obj.AddTag(Movable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMovableTag(this IEntity obj) => obj.DelTag(Movable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectileTag(this IEntity obj) => obj.HasTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddProjectileTag(this IEntity obj) => obj.AddTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectileTag(this IEntity obj) => obj.DelTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMeleeTag(this IEntity obj) => obj.HasTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMeleeTag(this IEntity obj) => obj.AddTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMeleeTag(this IEntity obj) => obj.DelTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasVisualEffectTag(this IEntity obj) => obj.HasTag(VisualEffect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddVisualEffectTag(this IEntity obj) => obj.AddTag(VisualEffect);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelVisualEffectTag(this IEntity obj) => obj.DelTag(VisualEffect);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Rigidbody GetRigidbody(this IEntity obj) => obj.GetValue<Rigidbody>(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRigidbody(this IEntity obj, out Rigidbody value) => obj.TryGetValue(Rigidbody, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRigidbody(this IEntity obj, Rigidbody value) => obj.AddValue(Rigidbody, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRigidbody(this IEntity obj) => obj.HasValue(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRigidbody(this IEntity obj) => obj.DelValue(Rigidbody);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRigidbody(this IEntity obj, Rigidbody value) => obj.SetValue(Rigidbody, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioSource GetAudioSource(this IEntity obj) => obj.GetValue<AudioSource>(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAudioSource(this IEntity obj, out AudioSource value) => obj.TryGetValue(AudioSource, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAudioSource(this IEntity obj, AudioSource value) => obj.AddValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAudioSource(this IEntity obj) => obj.HasValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAudioSource(this IEntity obj) => obj.DelValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAudioSource(this IEntity obj, AudioSource value) => obj.SetValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetCooldown(this IEntity obj) => obj.GetValue<Cooldown>(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCooldown(this IEntity obj, out Cooldown value) => obj.TryGetValue(Cooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCooldown(this IEntity obj, Cooldown value) => obj.AddValue(Cooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCooldown(this IEntity obj) => obj.HasValue(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCooldown(this IEntity obj) => obj.DelValue(Cooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCooldown(this IEntity obj, Cooldown value) => obj.SetValue(Cooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Transform> GetTarget(this IEntity obj) => obj.GetValue<IReactiveVariable<Transform>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IEntity obj, out IReactiveVariable<Transform> value) => obj.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTarget(this IEntity obj, IReactiveVariable<Transform> value) => obj.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IEntity obj, IReactiveVariable<Transform> value) => obj.SetValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AnimationEventReceiver GetAnimationEventReceiver(this IEntity obj) => obj.GetValue<AnimationEventReceiver>(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationEventReceiver(this IEntity obj, out AnimationEventReceiver value) => obj.TryGetValue(AnimationEventReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimationEventReceiver(this IEntity obj, AnimationEventReceiver value) => obj.AddValue(AnimationEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationEventReceiver(this IEntity obj) => obj.HasValue(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationEventReceiver(this IEntity obj) => obj.DelValue(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationEventReceiver(this IEntity obj, AnimationEventReceiver value) => obj.SetValue(AnimationEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LayerMask GetGroundLayerMask(this IEntity obj) => obj.GetValue<LayerMask>(GroundLayerMask);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGroundLayerMask(this IEntity obj, out LayerMask value) => obj.TryGetValue(GroundLayerMask, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGroundLayerMask(this IEntity obj, LayerMask value) => obj.AddValue(GroundLayerMask, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGroundLayerMask(this IEntity obj) => obj.HasValue(GroundLayerMask);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGroundLayerMask(this IEntity obj) => obj.DelValue(GroundLayerMask);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGroundLayerMask(this IEntity obj, LayerMask value) => obj.SetValue(GroundLayerMask, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static CollisionEventReceiver GetCollisionEventReceiver(this IEntity obj) => obj.GetValue<CollisionEventReceiver>(CollisionEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCollisionEventReceiver(this IEntity obj, out CollisionEventReceiver value) => obj.TryGetValue(CollisionEventReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCollisionEventReceiver(this IEntity obj, CollisionEventReceiver value) => obj.AddValue(CollisionEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCollisionEventReceiver(this IEntity obj) => obj.HasValue(CollisionEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCollisionEventReceiver(this IEntity obj) => obj.DelValue(CollisionEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCollisionEventReceiver(this IEntity obj, CollisionEventReceiver value) => obj.SetValue(CollisionEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEventReceiver GetTriggerEventReceiver(this IEntity obj) => obj.GetValue<TriggerEventReceiver>(TriggerEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTriggerEventReceiver(this IEntity obj, out TriggerEventReceiver value) => obj.TryGetValue(TriggerEventReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTriggerEventReceiver(this IEntity obj, TriggerEventReceiver value) => obj.AddValue(TriggerEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTriggerEventReceiver(this IEntity obj) => obj.HasValue(TriggerEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTriggerEventReceiver(this IEntity obj) => obj.DelValue(TriggerEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTriggerEventReceiver(this IEntity obj, TriggerEventReceiver value) => obj.SetValue(TriggerEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Health GetHealth(this IEntity obj) => obj.GetValue<Health>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity obj, out Health value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IEntity obj, Health value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity obj, Health value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<TakeDamageArgs> GetDeathEvent(this IEntity obj) => obj.GetValue<IReactiveVariable<TakeDamageArgs>>(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathEvent(this IEntity obj, out IReactiveVariable<TakeDamageArgs> value) => obj.TryGetValue(DeathEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDeathEvent(this IEntity obj, IReactiveVariable<TakeDamageArgs> value) => obj.AddValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathEvent(this IEntity obj) => obj.HasValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathEvent(this IEntity obj) => obj.DelValue(DeathEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathEvent(this IEntity obj, IReactiveVariable<TakeDamageArgs> value) => obj.SetValue(DeathEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<TakeDamageArgs> GetTakeDamageEvent(this IEntity obj) => obj.GetValue<IEvent<TakeDamageArgs>>(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTakeDamageEvent(this IEntity obj, out IEvent<TakeDamageArgs> value) => obj.TryGetValue(TakeDamageEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTakeDamageEvent(this IEntity obj, IEvent<TakeDamageArgs> value) => obj.AddValue(TakeDamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTakeDamageEvent(this IEntity obj) => obj.HasValue(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTakeDamageEvent(this IEntity obj) => obj.DelValue(TakeDamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTakeDamageEvent(this IEntity obj, IEvent<TakeDamageArgs> value) => obj.SetValue(TakeDamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealEvent(this IEntity obj) => obj.GetValue<IReactiveVariable<int>>(HealEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealEvent(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValue(HealEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealEvent(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(HealEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealEvent(this IEntity obj) => obj.HasValue(HealEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealEvent(this IEntity obj) => obj.DelValue(HealEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealEvent(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(HealEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetRotateDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(RotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(RotateDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotateDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(RotateDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateDirection(this IEntity obj) => obj.HasValue(RotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateDirection(this IEntity obj) => obj.DelValue(RotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(RotateDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetRotateCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotateCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IEntity obj) => obj.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IEntity obj) => obj.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetAngularSpeed(this IEntity obj) => obj.GetValue<IValue<float>>(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAngularSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValue(AngularSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAngularSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAngularSpeed(this IEntity obj) => obj.HasValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAngularSpeed(this IEntity obj) => obj.DelValue(AngularSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAngularSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(AngularSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetMoveCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IEntity obj) => obj.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IEntity obj) => obj.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetMoveSpeed(this IEntity obj) => obj.GetValue<IReactiveVariable<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IWeaponEntity> GetCurrentWeapon(this IEntity obj) => obj.GetValue<IReactiveVariable<IWeaponEntity>>(CurrentWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentWeapon(this IEntity obj, out IReactiveVariable<IWeaponEntity> value) => obj.TryGetValue(CurrentWeapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCurrentWeapon(this IEntity obj, IReactiveVariable<IWeaponEntity> value) => obj.AddValue(CurrentWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCurrentWeapon(this IEntity obj) => obj.HasValue(CurrentWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentWeapon(this IEntity obj) => obj.DelValue(CurrentWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentWeapon(this IEntity obj, IReactiveVariable<IWeaponEntity> value) => obj.SetValue(CurrentWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetAttackCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(AttackCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(AttackCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackCondition(this IEntity obj) => obj.HasValue(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackCondition(this IEntity obj) => obj.DelValue(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(AttackCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetAttackAction(this IEntity obj) => obj.GetValue<IAction>(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAction(this IEntity obj, out IAction value) => obj.TryGetValue(AttackAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackAction(this IEntity obj, IAction value) => obj.AddValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAction(this IEntity obj) => obj.HasValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAction(this IEntity obj) => obj.DelValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAction(this IEntity obj, IAction value) => obj.SetValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetAttackEvent(this IEntity obj) => obj.GetValue<IEvent>(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(AttackEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackEvent(this IEntity obj, IEvent value) => obj.AddValue(AttackEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackEvent(this IEntity obj) => obj.HasValue(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackEvent(this IEntity obj) => obj.DelValue(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackEvent(this IEntity obj, IEvent value) => obj.SetValue(AttackEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<bool> GetIsUsedItem(this IEntity obj) => obj.GetValue<IVariable<bool>>(IsUsedItem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetIsUsedItem(this IEntity obj, out IVariable<bool> value) => obj.TryGetValue(IsUsedItem, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddIsUsedItem(this IEntity obj, IVariable<bool> value) => obj.AddValue(IsUsedItem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasIsUsedItem(this IEntity obj) => obj.HasValue(IsUsedItem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelIsUsedItem(this IEntity obj) => obj.DelValue(IsUsedItem);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetIsUsedItem(this IEntity obj, IVariable<bool> value) => obj.SetValue(IsUsedItem, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetItemUseAction(this IEntity obj) => obj.GetValue<IAction>(ItemUseAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetItemUseAction(this IEntity obj, out IAction value) => obj.TryGetValue(ItemUseAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddItemUseAction(this IEntity obj, IAction value) => obj.AddValue(ItemUseAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasItemUseAction(this IEntity obj) => obj.HasValue(ItemUseAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelItemUseAction(this IEntity obj) => obj.DelValue(ItemUseAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetItemUseAction(this IEntity obj, IAction value) => obj.SetValue(ItemUseAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetItemTakeEvent(this IEntity obj) => obj.GetValue<IEvent>(ItemTakeEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetItemTakeEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(ItemTakeEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddItemTakeEvent(this IEntity obj, IEvent value) => obj.AddValue(ItemTakeEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasItemTakeEvent(this IEntity obj) => obj.HasValue(ItemTakeEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelItemTakeEvent(this IEntity obj) => obj.DelValue(ItemTakeEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetItemTakeEvent(this IEntity obj, IEvent value) => obj.SetValue(ItemTakeEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetHealSize(this IEntity obj) => obj.GetValue<IValue<int>>(HealSize);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealSize(this IEntity obj, out IValue<int> value) => obj.TryGetValue(HealSize, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealSize(this IEntity obj, IValue<int> value) => obj.AddValue(HealSize, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealSize(this IEntity obj) => obj.HasValue(HealSize);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealSize(this IEntity obj) => obj.DelValue(HealSize);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealSize(this IEntity obj, IValue<int> value) => obj.SetValue(HealSize, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetAmmoSize(this IEntity obj) => obj.GetValue<IValue<int>>(AmmoSize);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmoSize(this IEntity obj, out IValue<int> value) => obj.TryGetValue(AmmoSize, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmoSize(this IEntity obj, IValue<int> value) => obj.AddValue(AmmoSize, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmoSize(this IEntity obj) => obj.HasValue(AmmoSize);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmoSize(this IEntity obj) => obj.DelValue(AmmoSize);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmoSize(this IEntity obj, IValue<int> value) => obj.SetValue(AmmoSize, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetStartVisualEffectAction(this IEntity obj) => obj.GetValue<IAction>(StartVisualEffectAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetStartVisualEffectAction(this IEntity obj, out IAction value) => obj.TryGetValue(StartVisualEffectAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddStartVisualEffectAction(this IEntity obj, IAction value) => obj.AddValue(StartVisualEffectAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasStartVisualEffectAction(this IEntity obj) => obj.HasValue(StartVisualEffectAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelStartVisualEffectAction(this IEntity obj) => obj.DelValue(StartVisualEffectAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetStartVisualEffectAction(this IEntity obj, IAction value) => obj.SetValue(StartVisualEffectAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetStopVisualEffectAction(this IEntity obj) => obj.GetValue<IAction>(StopVisualEffectAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetStopVisualEffectAction(this IEntity obj, out IAction value) => obj.TryGetValue(StopVisualEffectAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddStopVisualEffectAction(this IEntity obj, IAction value) => obj.AddValue(StopVisualEffectAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasStopVisualEffectAction(this IEntity obj) => obj.HasValue(StopVisualEffectAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelStopVisualEffectAction(this IEntity obj) => obj.DelValue(StopVisualEffectAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetStopVisualEffectAction(this IEntity obj, IAction value) => obj.SetValue(StopVisualEffectAction, value);
    }
}
