using System;
using System.Collections.Generic;

namespace Atomic.Contexts
{
    public partial class Context
    {
        public event Action<IContextController> OnControllerAdded;
        public event Action<IContextController> OnControllerRemoved;
        public event Action OnControllersCleared;

        public IReadOnlyCollection<IContextController> Controllers => this.controllers;

        private readonly HashSet<IContextController> controllers = new();

        public T GetController<T>() where T : IContextController
        {
            foreach (IContextController controller in this.controllers)
                if (controller is T tController)
                    return tController;

            return default;
        }

        public bool TryGetController<T>(out T result) where T : IContextController
        {
            foreach (IContextController controller in this.controllers)
            {
                if (controller is T tController)
                {
                    result = tController;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public bool HasController(IContextController controller)
        {
            return this.controllers.Contains(controller);
        }

        public bool HasController<T>() where T : IContextController
        {
            foreach (IContextController controller in this.controllers)
                if (controller is T)
                    return true;

            return false;
        }

        public bool AddController<T>() where T : IContextController, new()
        {
            return this.AddController(new T());
        }

        public bool AddController(IContextController controller)
        {
            if (!this.controllers.Add(controller))
                return false;

            if (this.initialized && controller is IContextInit initController) initController.Init(this);
            if (this.enabled && controller is IContextEnable enableSystem) enableSystem.Enable(this);

            if (controller is IContextUpdate update) this.updates.Add(update);
            if (controller is IContextFixedUpdate fixedUpdate) this.fixedUpdates.Add(fixedUpdate);
            if (controller is IContextLateUpdate lateUpdate) this.lateUpdates.Add(lateUpdate);

            this.OnControllerAdded?.Invoke(controller);
            return true;
        }

        public bool DelController<T>() where T : IContextController
        {
            T controller = this.GetController<T>();
            return controller != null && this.DelController(controller);
        }

        public bool DelController(IContextController controller)
        {
            if (!this.controllers.Remove(controller))
                return false;

            if (controller is IContextUpdate update) this.updates.Remove(update);
            if (controller is IContextFixedUpdate fixedUpdate) this.fixedUpdates.Remove(fixedUpdate);
            if (controller is IContextLateUpdate lateUpdate) this.lateUpdates.Remove(lateUpdate);
            
            if (this.enabled && controller is IContextDisable disableSystem) disableSystem.Disable(this);
            if (this.initialized && controller is IContextDispose disposeSystem) disposeSystem.Dispose(this);

            this.OnControllerRemoved?.Invoke(controller);
            return true;
        }
        
        public bool ClearControllers()
        {
            if (this.controllers.Count <= 0)
                return false;
            
            this.controllers.Clear();
            this.ClearLifecycle();
            this.OnControllersCleared?.Invoke();
            return true;
        }
    }
}