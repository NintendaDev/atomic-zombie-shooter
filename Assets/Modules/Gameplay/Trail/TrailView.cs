using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.Gameplay
{
    public sealed class TrailView : MonoBehaviour
    {
        [SerializeField, Required] private TrailRenderer _trailPrefab;
        [SerializeField] private Transform _trailParent;
        [SerializeField] private Vector3 _trailScale = new(5, 5, 2.5f);
        [SerializeField] private Vector3 _trailOffset = new(0, 0, -1.5f);

        private TrailRenderer _trail;

        public void Show()
        {
            _trail = Instantiate(_trailPrefab, _trailParent);

            Transform transform = _trail.transform;
            transform.localScale = _trailScale;
            transform.localPosition = _trailOffset;
            transform.localEulerAngles = Vector3.zero;

            _trail.SetPositions(Array.Empty<Vector3>());
            _trail.Clear();
            _trail.emitting = true;
        }

        public void Hide()
        {
            if (_trail != null)
            {
                UnspawnTrail(_trail).Forget();
                _trail = null;
            }
        }

        private async UniTaskVoid UnspawnTrail(TrailRenderer trail)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(trail.time), DelayType.DeltaTime);
            Destroy(trail.gameObject);
        }
    }
}