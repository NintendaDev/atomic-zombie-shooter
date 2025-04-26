using System;
using UnityEngine;

namespace Atomic.Presenters
{
    public class Presenter : MonoBehaviour, IPresenter
    {
        public event Action OnInitialized;
        public event Action OnShown;
        public event Action OnHidden;
        public event Action OnDisposed;

        public event Action<bool> OnVisible;

        public string Name => this.name;
        public bool IsInitialized => _initialized;
        public bool IsShown => _shown;

        private bool _initialized;
        private bool _shown;

        public void Show() => this.gameObject.SetActive(true);
        public void Hide() => this.gameObject.SetActive(false);
        public void SetVisible(bool visible) => this.gameObject.SetActive(visible);

        public T GetChild<T>() where T : IPresenter => this.gameObject.GetComponentInChildren<T>();
        public T[] GetChildren<T>() where T : IPresenter => this.gameObject.GetComponentsInChildren<T>();
        public T GetParent<T>() where T : IPresenter => this.gameObject.GetComponentInParent<T>();

        private void Awake()
        {
            this.OnCreate();
        }

        private void Start()
        {
            this.InitInternal();
            this.ShowInternal();
        }

        private void OnEnable()
        {
            if (_initialized)
                this.ShowInternal();
        }

        private void OnDisable()
        {
            if (_initialized)
                this.HideInternal();
        }

        private void OnDestroy()
        {
            if (_initialized)
                this.DisposeInternal();
        }

        private void InitInternal()
        {
            this.OnInit();
            _initialized = true;
            this.OnInitialized?.Invoke();
        }

        private void DisposeInternal()
        {
            this.OnDispose();
            this.OnDisposed?.Invoke();
        }

        private void ShowInternal()
        {
            PresenterUpdater.AddPresenter(this);

            this.OnShow();

            _shown = true;
            this.OnShown?.Invoke();
            this.OnVisible?.Invoke(true);
        }

        private void HideInternal()
        {
            PresenterUpdater.DelPresenter(this);

            this.OnHide();
            _shown = false;

            this.OnHidden?.Invoke();
            this.OnVisible?.Invoke(false);
        }
        
        protected virtual void OnCreate()
        {
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnDispose()
        {
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}