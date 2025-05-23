#if ODIN_INSPECTOR
using System;

namespace Atomic.Entities
{
    [Serializable]
    public class ElementEntityInstaller<T> : ValueEntityInstaller<T> where T : IEntityBehaviour
    {
        public override void Install(IEntity entity)
        {
            base.Install(entity);
            entity.AddBehaviour(this.value);
        }
    }
}
#endif