using System.ComponentModel.DataAnnotations;
using Atomic.Elements;
using Atomic.Presenters;
using Game.Gameplay.Contexts.Game;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class KillsScorePresenter : Presenter
    {
        [SerializeField, Required] private TMP_Text _killsView;
        
        private IReactiveVariable<int> _score;

        protected override void OnInit()
        {
            base.OnInit();
            _score = GameContext.Instance.GetScore();
            OnScoreChange(_score.Value);
            
            _score.Subscribe(OnScoreChange);
        }
        
        protected override void OnDispose()
        {
            _score.Unsubscribe(OnScoreChange);
        }
        
        private void OnScoreChange(int score) => _killsView.text = score.ToString();
    }
}