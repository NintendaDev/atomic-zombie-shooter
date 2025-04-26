using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Atomic.Contexts
{
    public abstract class SceneContextInstaller : MonoBehaviour, IContextInstaller
    {
        public abstract void Install(IContext context);

        protected static bool IsPlayMode()
        {
#if UNITY_EDITOR
            return EditorApplication.isPlaying;
#else
            return true;
#endif
        }

        protected static bool IsEditMode()
        {
#if UNITY_EDITOR
            return !EditorApplication.isPlaying && !EditorApplication.isCompiling;
#else
            return false;
#endif
        }
    }

    public abstract class SceneContextInstaller<T> : SceneContextInstaller where T : IContext
    {
        public sealed override void Install(IContext context) => this.Install((T) context);
        
        protected abstract void Install(T context);
    }
}