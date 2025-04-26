using System;

namespace Atomic.Presenters
{
    public interface IPresenter
    {
        event Action OnInitialized;
        event Action OnShown;
        event Action OnHidden;
        event Action OnDisposed;
        
        event Action<bool> OnVisible;

        string Name { get; }
        bool IsInitialized { get; }
        bool IsShown { get; }
        
        void Show();
        void Hide();
        void SetVisible(bool visible);

        T GetChild<T>() where T : IPresenter;
        T[] GetChildren<T>() where T : IPresenter;
        T GetParent<T>() where T : IPresenter;
    }
}