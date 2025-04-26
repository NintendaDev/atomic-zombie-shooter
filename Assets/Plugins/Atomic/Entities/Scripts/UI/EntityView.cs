using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Entities.UI
{
    [AddComponentMenu("Atomic/Entities/Entity View")]
    [DisallowMultipleComponent]
    public class EntityView : MonoBehaviour
    {
        [SerializeField]
        private List<EntityViewInstaller> _installers;

        private readonly List<IEntityBehaviour> _behaviours = new();
        private bool _installed;
        private IEntity _entity;

        public void Show(IEntity entity)
        {
            this.Install();
            _entity = entity;
            _entity.AddBehaviours(_behaviours);
        }

        public void Hide()
        {
            _entity.DelBehaviours(_behaviours);
            _entity = null;
        }

        public void AddBehaviour(IEntityBehaviour behaviour)
        {
            _behaviours.Add(behaviour);
            _entity?.AddBehaviour(behaviour);
        }

        public void DelBehaviour(IEntityBehaviour behaviour)
        {
            _behaviours.Remove(behaviour);
            _entity?.DelBehaviour(behaviour);
        }

        private void Install()
        {
            if (_installed)
                return;

            _installed = true;

            for (int i = 0, count = _installers.Count; i < count; i++)
            {
                EntityViewInstaller installer = _installers[i];
                if (installer != null)
                    installer.Install(this);
            }
        }
    }
}