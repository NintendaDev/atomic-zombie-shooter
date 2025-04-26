#if UNITY_EDITOR
using System;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        private void OnValidate()
        {
            this.AutoRefresh();
        }

        private void AutoRefresh()
        {
            if (!this.installInEditMode)
                return;

            if (EditorApplication.isPlaying || EditorApplication.isCompiling)
                return;

            try
            {
                this.SetRefreshCallbackToInstallers();
                this.RefreshInEditMode();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void SetRefreshCallbackToInstallers()
        {
            foreach (SceneEntityInstaller installer in this.installers)
                if (installer != null)
                    installer.m_refreshCallback = this.RefreshInEditMode;
        }

#if ODIN_INSPECTOR
        [FoldoutGroup("Debug")]
        [PropertyOrder(95)]
        [Button("Test Install"), HideInPlayMode]
        [GUIColor(0f, 0.83f, 1f)]
        [PropertySpace(SpaceAfter = 8, SpaceBefore = 8)]
#endif
        private void RefreshInEditMode()
        {
            if (this.entity == null)
                return;

            bool isPrefab = PrefabUtility.GetPrefabInstanceHandle(this.gameObject) == this.gameObject;
            if (!isPrefab)
            {
                this.DisableInEditMode();
                this.DisposeInEditMode();
            }

            this.entity.Clear();
            this.InstallInternal();

            if (!isPrefab)
            {
                this.entity.Name = this.name;
                this.InitInEditMode();
                this.EnableInEditMode();
            }
        }

        private void InitInEditMode()
        {
            if (this.entity.Initialized)
                return;

            foreach (IEntityBehaviour behaviour in this.entity.Behaviours)
                if (behaviour is IEntityInit dispose && IsEditModeSupported(behaviour))
                    dispose.Init(this.entity);
        }

        private void EnableInEditMode()
        {
            if (this.entity.Enabled)
                return;

            foreach (IEntityBehaviour behaviour in this.entity.Behaviours)
                if (behaviour is IEntityEnable dispose && IsEditModeSupported(behaviour))
                    dispose.Enable(this.entity);
        }

        private void DisableInEditMode()
        {
            if (!this.entity.Enabled)
                return;

            foreach (IEntityBehaviour behaviour in this.entity.Behaviours)
                if (behaviour is IEntityDisable disable && IsEditModeSupported(behaviour))
                    disable.Disable(this.entity);
        }

        private void DisposeInEditMode()
        {
            if (!this.entity.Initialized)
                return;

            foreach (IEntityBehaviour behaviour in entity.Behaviours)
            {
                if (behaviour is IEntityDispose dispose && IsEditModeSupported(behaviour))
                    dispose.Dispose(this.entity);
            }
        }

        private static bool IsEditModeSupported(IEntityBehaviour behaviour)
        {
            return behaviour.GetType().IsDefined(typeof(EditModeBehaviourAttribute));
        }
    }
}

#endif