#if ODIN_INSPECTOR
using System;
using UnityEngine;

namespace Atomic.Entities
{
    [Serializable]
    public sealed class ComponentEntityInstaller : ValueEntityInstaller<Component>
    {
    }
}
#endif