using System.Collections.Generic;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

using UnityEngine;

namespace Atomic.Entities
{
    [AddComponentMenu("Atomic/Entities/Entity")]
    [DisallowMultipleComponent, DefaultExecutionOrder(-1000)]
    public partial class SceneEntity : MonoBehaviour, IEntity
    {
        public string Name
        {
            get => this.entity.Name;
            set => this.entity.Name = value;
        }
        
        public int InstanceId
        {
            get { return entity.InstanceId; }
        }

        public bool Installed
        {
            get { return this.installed; }
        }

#if ODIN_INSPECTOR
        [GUIColor(0f, 0.83f, 1f)]
        [HideInPlayMode]
#endif
        [Tooltip("If this option is enabled, the Install() method will be called on Awake()")]
        [SerializeField]
        private bool installOnAwake = true;
        
#if ODIN_INSPECTOR
        [PropertySpace(SpaceBefore = 0)]
        [GUIColor(1f, 0.92156863f, 0.015686275f)]
        [HideInPlayMode]
        [InfoBox(
            "WARINING: If you create Unity objects or another heavy objects in the Install() method, be sure to turn off!",
            InfoMessageType.Warning,
            nameof(installInEditMode))
        ]
#endif
        [Tooltip("If this option is enabled, the Install() method will be called every time OnValidate is called in Edit Mode")]
        [SerializeField]
        private bool installInEditMode;

#if ODIN_INSPECTOR
        [HideInPlayMode]
#endif
        [Tooltip("Should dispose values when OnDestroy() called")]
        [SerializeField]
        private bool disposeValues = true;
        
#if ODIN_INSPECTOR
        [HideInPlayMode]
#endif
        [Tooltip("Specify the installers that will put values and systems to this context")]
        [Space, SerializeField]
        private List<SceneEntityInstaller> installers;


        internal readonly IEntity entity;

        private bool installed;

        public SceneEntity()
        {
            this.entity = new Entity(owner: this);
        }
        
        public void Install()
        {
            if (this.installed)
                return;

            this.InstallInternal();
            this.installed = true;
        }

        private void InstallInternal()
        {
            this.entity.Name = this.name;

            if (this.installers != null)
                for (int i = 0, count = this.installers.Count; i < count; i++)
                {
                    SceneEntityInstaller installer = this.installers[i];
                    if (installer != null)
                        installer.Install(this);
                    else
                        Debug.LogWarning("SceneEntity: Ops! Detected null installer!", this);
                }
            
            s_entities.TryAdd(this.entity, this);
        }

        protected virtual void Awake()
        {
            if (this.installOnAwake) this.Install();
        }

        protected virtual void OnDestroy()
        {
            if (this.disposeValues) this.entity.DisposeValues();
            s_entities.Remove(this.entity);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(entity)}: {entity}";
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is SceneEntity other && this.Equals(other);
        }

        public bool Equals(SceneEntity other)
        {
            return Equals(this.entity, other.entity);
        }

        public override int GetHashCode()
        {
            return this.entity.GetHashCode();
        }

        public void Clear()
        {
            this.entity.Clear();
        }
    }
}