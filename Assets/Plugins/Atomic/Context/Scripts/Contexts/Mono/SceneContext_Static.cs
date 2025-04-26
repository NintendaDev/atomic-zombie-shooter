using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Contexts
{
    public partial class SceneContext
    {
        public static SceneContext Create(
            string name = null,
            IReadOnlyDictionary<int, object> values = null,
            IEnumerable<IContextController> systems = null
        )
        {
            GameObject gameObject = new GameObject(name);
            SceneContext context = gameObject.AddComponent<SceneContext>();
            context.Name = name;
            context.AddValues(values);
            context.AddControllers(systems);

            context.Install();
            return context;
        }

        public static T Create<T>(
            string name = null,
            IReadOnlyDictionary<int, object> values = null,
            IEnumerable<IContextController> systems = null
        ) where T : SceneContext
        {
            GameObject gameObject = new GameObject(name);
            T context = gameObject.AddComponent<T>();
            
            context.AddValues(values);
            context.AddControllers(systems);
            
            context.Install();
            return context;
        }

        public static SceneContext Create(
            SceneContext prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent = null
        )
        {
            SceneContext context = Instantiate(prefab, position, rotation, parent);
            context.Install();
            return context;
        }
    }
}