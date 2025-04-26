#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Atomic.Events
{
    public partial class SceneEventBus
    {
        ///Events
        private static readonly IComparer<DebugEvent> _debugEventComparer = new DebugEvent.Comparer();
        private static readonly List<DebugEvent> _debugEventsCache = new();

        [InlineProperty]
        private struct DebugEvent
        {
            [ShowInInspector, ReadOnly]
            internal string name;

            internal readonly int id;

            public DebugEvent(string name, int id)
            {
                this.name = name;
                this.id = id;
            }
            
            public sealed class Comparer : IComparer<DebugEvent>
            {
                public int Compare(DebugEvent x, DebugEvent y)
                {
                    return string.Compare(x.name, y.name, StringComparison.Ordinal);
                }
            }
        }

        [Searchable]
        [FoldoutGroup("Debug")]
        [LabelText("Events")]
        [ShowInInspector, PropertyOrder(100)]
        [ListDrawerSettings(
            CustomRemoveElementFunction = nameof(Debug_UndeclareEvent),
            CustomRemoveIndexFunction = nameof(Debug_UndeclareEventAt),
            HideAddButton = true
        )]
        private List<DebugEvent> DebugEvents
        {
            get
            {
                _debugEventsCache.Clear();

                IReadOnlyCollection<int> events = _eventBus?.DefinedEvents;
                if (events == null)
                    return _debugEventsCache;

                foreach (int key in events)
                {
                    string name = EventBusUtils.IdToName(in key);
                    _debugEventsCache.Add(new DebugEvent(name, key));
                }

                _debugEventsCache.Sort(_debugEventComparer);
                return _debugEventsCache;
            }
            set
            {
                /** noting... **/
            }
        }

        private void Debug_UndeclareEvent(DebugEvent debugEvent)
        {
            if (_eventBus != null) _eventBus.Undef(debugEvent.id);
        }

        private void Debug_UndeclareEventAt(int index)
        {
            if (_eventBus != null) _eventBus.Undef(this.DebugEvents[index].id);
        }
    }
}
#endif