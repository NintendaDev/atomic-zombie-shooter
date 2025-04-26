/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;
using Game.Gameplay.Contexts.Player;

namespace Game.Gameplay.Contexts.Game
{
	public static class GameContextAPI
	{


		///Values
		public const int EntityPool = 1931115573; // PrefabEntityPool
		public const int PlayerContext = -122845622; // IPlayerContext
		public const int Enemies = -1212189790; // IReactiveList<IEntity>
		public const int Score = -212330411; // IReactiveVariable<int>
		public const int KillReward = 1191044733; // IValue<int>


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PrefabEntityPool GetEntityPool(this IGameContext obj) => obj.GetValue<PrefabEntityPool>(EntityPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEntityPool(this IGameContext obj, out PrefabEntityPool value) => obj.TryGetValue(EntityPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddEntityPool(this IGameContext obj, PrefabEntityPool value) => obj.AddValue(EntityPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEntityPool(this IGameContext obj) => obj.HasValue(EntityPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEntityPool(this IGameContext obj) => obj.DelValue(EntityPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEntityPool(this IGameContext obj, PrefabEntityPool value) => obj.SetValue(EntityPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IPlayerContext GetPlayerContext(this IGameContext obj) => obj.GetValue<IPlayerContext>(PlayerContext);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayerContext(this IGameContext obj, out IPlayerContext value) => obj.TryGetValue(PlayerContext, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerContext(this IGameContext obj, IPlayerContext value) => obj.AddValue(PlayerContext, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerContext(this IGameContext obj) => obj.HasValue(PlayerContext);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerContext(this IGameContext obj) => obj.DelValue(PlayerContext);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayerContext(this IGameContext obj, IPlayerContext value) => obj.SetValue(PlayerContext, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveList<IEntity> GetEnemies(this IGameContext obj) => obj.GetValue<IReactiveList<IEntity>>(Enemies);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetEnemies(this IGameContext obj, out IReactiveList<IEntity> value) => obj.TryGetValue(Enemies, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddEnemies(this IGameContext obj, IReactiveList<IEntity> value) => obj.AddValue(Enemies, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemies(this IGameContext obj) => obj.HasValue(Enemies);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemies(this IGameContext obj) => obj.DelValue(Enemies);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetEnemies(this IGameContext obj, IReactiveList<IEntity> value) => obj.SetValue(Enemies, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetScore(this IGameContext obj) => obj.GetValue<IReactiveVariable<int>>(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetScore(this IGameContext obj, out IReactiveVariable<int> value) => obj.TryGetValue(Score, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddScore(this IGameContext obj, IReactiveVariable<int> value) => obj.AddValue(Score, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasScore(this IGameContext obj) => obj.HasValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelScore(this IGameContext obj) => obj.DelValue(Score);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetScore(this IGameContext obj, IReactiveVariable<int> value) => obj.SetValue(Score, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetKillReward(this IGameContext obj) => obj.GetValue<IValue<int>>(KillReward);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetKillReward(this IGameContext obj, out IValue<int> value) => obj.TryGetValue(KillReward, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddKillReward(this IGameContext obj, IValue<int> value) => obj.AddValue(KillReward, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasKillReward(this IGameContext obj) => obj.HasValue(KillReward);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelKillReward(this IGameContext obj) => obj.DelValue(KillReward);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetKillReward(this IGameContext obj, IValue<int> value) => obj.SetValue(KillReward, value);
    }
}
