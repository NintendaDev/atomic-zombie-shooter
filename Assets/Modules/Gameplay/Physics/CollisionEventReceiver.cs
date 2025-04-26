using System;
using UnityEngine;

namespace Modules.Gameplay
{
    public sealed class CollisionEventReceiver : MonoBehaviour
    {
        public event Action<Collision> Entered;
        
        public event Action<Collision> Exited;

        private void OnCollisionEnter(Collision collision)
        {
            Entered?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            Exited?.Invoke(collision);
        }
    }
}