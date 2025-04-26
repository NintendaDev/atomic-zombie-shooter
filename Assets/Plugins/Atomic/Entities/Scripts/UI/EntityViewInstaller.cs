using UnityEngine;

namespace Atomic.Entities.UI
{
    public abstract class EntityViewInstaller : MonoBehaviour, IEntityViewInstaller
    {
        public abstract void Install(EntityView view);
    }
}