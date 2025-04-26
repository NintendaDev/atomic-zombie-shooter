using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Contexts.Player;
using Game.Gameplay.Entity.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Entity.Character
{
    public sealed class CharacterDebugger : MonoBehaviour
    {
        private IEntity _character;

        private void Awake()
        {
            _character = GameContext.Instance.GetPlayerContext().GetCharacter();
        }

        [Button, HideInEditorMode]
        private void TakeDamage(int damage)
        {
            _character.TakeDamage(new TakeDamageArgs(_character, damage));
        }

        [Button, HideInEditorMode]
        private void AddAmmo(int count)
        {
            _character.TryAddAmmo(count);
        }
        
        [Button, HideInEditorMode]
        private void Heal(int count)
        {
            _character.TryHeal(count);
        }
    }
}