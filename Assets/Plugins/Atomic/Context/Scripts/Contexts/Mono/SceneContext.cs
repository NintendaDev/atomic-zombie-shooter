using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Atomic.Contexts
{
    [AddComponentMenu("Atomic/Context/Context")]
    [DisallowMultipleComponent, DefaultExecutionOrder(-1000)]
    public partial class SceneContext : MonoBehaviour, IContext
    {
#if ODIN_INSPECTOR
        [GUIColor(0f, 0.83f, 1f)]
        [HideInPlayMode]
#endif
        [Tooltip("If this option is enabled, the Install() method will be called on Awake()")]
        [SerializeField]
        private bool installOnAwake = true;

#if ODIN_INSPECTOR
        [PropertySpace(SpaceBefore = 0, SpaceAfter = 12)]
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
        [Tooltip("Should context be on DontDestroyOnLoad scene after Awake()")]
        [SerializeField]
        private bool dontDestroyOnLoad;
        
#if ODIN_INSPECTOR
        [HideInPlayMode]
#endif
        [Tooltip("Specify the parent contexts during Install()")]
        [SerializeField]
        private SceneContext initialParent;
        
#if ODIN_INSPECTOR
        [HideInPlayMode]
#endif
        [Tooltip("Specify the installers that will put values and systems to this context")]
        [Space, SerializeField]
        private List<SceneContextInstaller> installers = new();

#if ODIN_INSPECTOR
        [HideInPlayMode]
#endif
        [Tooltip("Specify the child contexts that will Installed with this context")]
        [Space, SerializeField]
        private List<SceneContext> children;

        private readonly Context context;
        
        private bool installed;
        
        public string Name
        {
            get => this.context.Name;
            set => this.context.Name = value;
        }

        public IContext Parent
        {
            get { return this.context.Parent; }
            set { this.context.Parent = value; }
        }

        public SceneContext()
        {
            this.context = new Context(owner: this);
        }


        
        public void Install()
        {
            this.Install(this.initialParent);
        }

        public void Install(IContext parent)
        {
            if (!this.installed)
            {
                this.InstallInternal(parent);
                this.installed = true;
            }
        }
        
        private void InstallInternal(IContext parent)
        {
            this.context.Clear();
            this.context.Name = this.name;
            this.context.Parent = parent;

            for (int i = 0, count = this.installers.Count; i < count; i++)
            {
                SceneContextInstaller installer = this.installers[i];
                if (installer != null)
                    installer.Install(this);
                else
                    Debug.LogWarning("SceneContext: Ops! Detected null installer!", this);
            }

            foreach (SceneContext child in this.children)
                child.Install(this);
        }

        protected virtual void Awake()
        {
            if (this.installOnAwake)
                this.Install();

            if (this.dontDestroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
        }

        protected virtual void OnValidate()
        {
#if UNITY_EDITOR
            this.InstallInEditMode();
#endif
        }

        public void Clear() => this.context.Clear();

#if UNITY_EDITOR

#if ODIN_INSPECTOR
        [FoldoutGroup("Debug")]
        [Button("Install")]
        [ShowInInspector, PropertyOrder(100)]
        [GUIColor(1f, 0.92156863f, 0.015686275f)]
        [HideInPlayMode, ShowIf(nameof(installInEditMode))]
#endif
        
        private void InstallInEditMode()
        {
            if (!this.installInEditMode)
                return;

            if (EditorApplication.isPlaying || EditorApplication.isCompiling) 
                return;

            try
            {
                this.InstallInternal(this.initialParent);
            }
            catch (Exception)
            {
                /** ignored **/
            }
        }
#endif
    }
}