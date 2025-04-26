using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Entities.UI
{
    [CreateAssetMenu(
        fileName = "Entity View Catalog",
        menuName = "Atomic/Entities/Entity View Catalog"
    )]
    public sealed class EntityViewCatalog : ScriptableObject
    {
        public IEnumerable<EntityView> Prefabs => _prefabs;

        [SerializeField]
        private EntityView[] _prefabs;
    }
}


//
// public EntityView GetPrefab(string name)
// {
//     for (int i = 0, count = _prefabs.Length; i < count; i++)
//     {
//         EntityView view = _prefabs[i];
//         if (view.name == name)
//             return view;
//     }
//
//     throw new Exception($"Presenter prefab with name {name} is not found!");
// }