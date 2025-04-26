/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Modules.Common;
using Atomic.Elements;
using Modules.Gameplay;

namespace Game.Gameplay.Contexts.Player
{
	public static class PlayerContextAPI
	{


		///Values
		public const int Character = 294335127; // IEntity
		public const int FireCondition = -280402907; // IExpression<bool>
		public const int FireJoystick = 189632099; // Joystick
		public const int MoveJoystick = -1686028204; // Joystick
		public const int JoystickActiveThreshold = -639986422; // IValue<float>
		public const int FirstAttackDelay = -1172997188; // IValue<float>
		public const int FirstFireCooldown = -947457620; // Cooldown


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetCharacter(this IPlayerContext obj) => obj.GetValue<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IPlayerContext obj, out IEntity value) => obj.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacter(this IPlayerContext obj, IEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IPlayerContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IPlayerContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IPlayerContext obj, IEntity value) => obj.SetValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetFireCondition(this IPlayerContext obj) => obj.GetValue<IExpression<bool>>(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCondition(this IPlayerContext obj, out IExpression<bool> value) => obj.TryGetValue(FireCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireCondition(this IPlayerContext obj, IExpression<bool> value) => obj.AddValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCondition(this IPlayerContext obj) => obj.HasValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCondition(this IPlayerContext obj) => obj.DelValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCondition(this IPlayerContext obj, IExpression<bool> value) => obj.SetValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetFireJoystick(this IPlayerContext obj) => obj.GetValue<Joystick>(FireJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireJoystick(this IPlayerContext obj, out Joystick value) => obj.TryGetValue(FireJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireJoystick(this IPlayerContext obj, Joystick value) => obj.AddValue(FireJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireJoystick(this IPlayerContext obj) => obj.HasValue(FireJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireJoystick(this IPlayerContext obj) => obj.DelValue(FireJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireJoystick(this IPlayerContext obj, Joystick value) => obj.SetValue(FireJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetMoveJoystick(this IPlayerContext obj) => obj.GetValue<Joystick>(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveJoystick(this IPlayerContext obj, out Joystick value) => obj.TryGetValue(MoveJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveJoystick(this IPlayerContext obj, Joystick value) => obj.AddValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveJoystick(this IPlayerContext obj) => obj.HasValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveJoystick(this IPlayerContext obj) => obj.DelValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveJoystick(this IPlayerContext obj, Joystick value) => obj.SetValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetJoystickActiveThreshold(this IPlayerContext obj) => obj.GetValue<IValue<float>>(JoystickActiveThreshold);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetJoystickActiveThreshold(this IPlayerContext obj, out IValue<float> value) => obj.TryGetValue(JoystickActiveThreshold, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddJoystickActiveThreshold(this IPlayerContext obj, IValue<float> value) => obj.AddValue(JoystickActiveThreshold, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasJoystickActiveThreshold(this IPlayerContext obj) => obj.HasValue(JoystickActiveThreshold);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelJoystickActiveThreshold(this IPlayerContext obj) => obj.DelValue(JoystickActiveThreshold);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetJoystickActiveThreshold(this IPlayerContext obj, IValue<float> value) => obj.SetValue(JoystickActiveThreshold, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetFirstAttackDelay(this IPlayerContext obj) => obj.GetValue<IValue<float>>(FirstAttackDelay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirstAttackDelay(this IPlayerContext obj, out IValue<float> value) => obj.TryGetValue(FirstAttackDelay, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFirstAttackDelay(this IPlayerContext obj, IValue<float> value) => obj.AddValue(FirstAttackDelay, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirstAttackDelay(this IPlayerContext obj) => obj.HasValue(FirstAttackDelay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirstAttackDelay(this IPlayerContext obj) => obj.DelValue(FirstAttackDelay);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirstAttackDelay(this IPlayerContext obj, IValue<float> value) => obj.SetValue(FirstAttackDelay, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetFirstFireCooldown(this IPlayerContext obj) => obj.GetValue<Cooldown>(FirstFireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirstFireCooldown(this IPlayerContext obj, out Cooldown value) => obj.TryGetValue(FirstFireCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFirstFireCooldown(this IPlayerContext obj, Cooldown value) => obj.AddValue(FirstFireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirstFireCooldown(this IPlayerContext obj) => obj.HasValue(FirstFireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirstFireCooldown(this IPlayerContext obj) => obj.DelValue(FirstFireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirstFireCooldown(this IPlayerContext obj, Cooldown value) => obj.SetValue(FirstFireCooldown, value);
    }
}
