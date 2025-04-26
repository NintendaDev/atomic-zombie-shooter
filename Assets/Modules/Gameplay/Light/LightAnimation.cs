using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.Gameplay
{
    public sealed class LightAnimation : MonoBehaviour
    {
        [SerializeField, Required] private new Light _light; 
        [SerializeField] private float _endIntensity = 1;
        [SerializeField, MinValue(0)] private float _duration = 0.5f;

        private void Start()
        {
            _light.DOIntensity(this._endIntensity, _duration)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}