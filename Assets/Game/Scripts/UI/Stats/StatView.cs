using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;
        
        [SerializeField] private Image _progressBar;

        public void SetText(string health)
        {
            _valueText.text = health;
        }
        
        public void SetProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}