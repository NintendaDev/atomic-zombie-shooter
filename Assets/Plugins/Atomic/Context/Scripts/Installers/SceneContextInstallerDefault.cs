#if ODIN_INSPECTOR
using UnityEngine;

namespace Atomic.Contexts
{
    [AddComponentMenu("Atomic/Context/Context Installer")]
    public sealed class SceneContextInstallerDefault : SceneContextInstaller
    {
        [Space(12)]
        [SerializeReference]
        private IContextInstaller[] installers;

        [Space(12)]
        [SerializeReference]
        private IContextController[] systems;
        
        public override void Install(IContext context)
        {
            if (this.installers != null)
            {
                for (int i = 0, count = this.installers.Length; i < count; i++)
                {
                    IContextInstaller installer = this.installers[i];
                    installer?.Install(context);
                }
            }

            if (this.systems != null)
            {
                for (int i = 0, count = this.systems.Length; i < count; i++)
                {
                    IContextController controller = this.systems[i];
                    if (controller != null)
                    {
                        context.AddController(controller);
                    }
                }
            }
        }
    }
}
#endif