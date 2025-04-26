using UnityEngine;

namespace Modules.Gameplay
{
    public sealed class Cooldown
    {
        private readonly float _duration;
        private float _current;

        public Cooldown(float duration)
        {
            _duration = duration;
        }

        public Cooldown(float duration, float current) : this(duration)
        {
            _current = current;
        }

        public bool IsExpired()
        {
            return _current <= 0;
        }

        public float GetProgress()
        {
            return _current / _duration;
        }

        public void Reset()
        {
            _current = _duration;
        }

        public void Tick(float deltaTime)
        {
            _current = Mathf.Max(0, _current - deltaTime);
        }
    }
}