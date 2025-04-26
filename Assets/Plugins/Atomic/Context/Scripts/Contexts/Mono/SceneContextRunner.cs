using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic.Contexts
{
    [AddComponentMenu("Atomic/Contexts/Context Runner")]
    [RequireComponent(typeof(SceneContext))]
    [DisallowMultipleComponent, DefaultExecutionOrder(-1000)]
    public sealed class SceneContextRunner : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [GUIColor(0f, 0.83f, 1f)]
        [HideInPlayMode]
#endif
        [Tooltip("If enabled then SceneContext.Install() will happened on Awake()")]
        [SerializeField]
        private bool installOnAwake;

#if ODIN_INSPECTOR
        [GUIColor(0f, 0.83f, 1f)]
        [HideInPlayMode]
#endif
        [Tooltip("If enabled then dependency injection will happened before initialization")]
        [SerializeField]
        private bool diEnabled = true;
        
        [Space, SerializeField]
        private SceneContext[] contexts;

        private bool started;

        private void Reset()
        {
            this.contexts = this.GetComponentsInChildren<SceneContext>();
        }

        private void Awake()
        {
            if (!this.installOnAwake)
                return;

            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.Install();
            }
        }

        private void Start()
        {
            if (this.diEnabled) 
                this.Construct();

            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.Init();
                context.Enable();
            }
            
            this.started = true;
        }

        private void Construct()
        {
            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.Construct();
            }
        }
        
        private void OnEnable()
        {
            if (!this.started)
                return;

            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.Enable();
            }
        }

        private void OnDisable()
        {
            if (!this.started)
                return;

            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.Disable();
            }
        }

        private void OnDestroy()
        {
            if (!this.started)
                return;
            
            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.Dispose();
            }
        }

        private void Update()
        {
            if (!this.started)
                return;
            
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (!this.started)
                return;
            
            float deltaTime = Time.fixedDeltaTime;
            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (!this.started)
                return;
            
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = this.contexts.Length; i < count; i++)
            {
                SceneContext context = this.contexts[i];
                context.OnLateUpdate(deltaTime);
            }
        }
    }
}