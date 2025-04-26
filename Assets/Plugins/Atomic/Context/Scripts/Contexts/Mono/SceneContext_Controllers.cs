using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial class SceneContext
    {
        public event Action<IContextController> OnControllerAdded
        {
            add => this.context.OnControllerAdded += value;
            remove => this.context.OnControllerAdded -= value;
        }

        public event Action<IContextController> OnControllerRemoved
        {
            add => this.context.OnControllerRemoved += value;
            remove => this.context.OnControllerRemoved -= value;
        }

        public event Action OnControllersCleared
        {
            add => this.context.OnControllersCleared += value;
            remove => this.context.OnControllersCleared -= value;
        }

        public IReadOnlyCollection<IContextController> Controllers => this.context.Controllers;

        public T GetController<T>() where T : IContextController => this.context.GetController<T>();

        public bool TryGetController<T>(out T result) where T : IContextController => this.context.TryGetController(out result);

        public bool AddController(IContextController controller) => this.context.AddController(controller);

        public bool AddController<T>() where T : IContextController, new() => this.context.AddController<T>();

        public bool DelController(IContextController controller) => this.context.DelController(controller);

        public bool DelController<T>() where T : IContextController => this.context.DelController<T>();

        public bool HasController(IContextController controller) => this.context.HasController(controller);

        public bool HasController<T>() where T : IContextController => this.context.HasController<T>();
        
        public bool ClearControllers() => context.ClearControllers();

    }
}