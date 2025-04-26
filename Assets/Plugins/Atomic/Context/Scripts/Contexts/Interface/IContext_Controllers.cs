using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial interface IContext
    {
        event Action<IContextController> OnControllerAdded;
        event Action<IContextController> OnControllerRemoved;
        event Action OnControllersCleared;
        
        IReadOnlyCollection<IContextController> Controllers { get; }
        
        T GetController<T>() where T : IContextController;
        bool TryGetController<T>(out T result) where T : IContextController;

        bool AddController(IContextController controller);
        bool AddController<T>() where T : IContextController, new();
        
        bool DelController(IContextController controller);
        bool DelController<T>() where T : IContextController;
        
        bool HasController(IContextController controller);
        bool HasController<T>() where T : IContextController;

        bool ClearControllers();
    }
}