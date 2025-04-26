#if ODIN_INSPECTOR
using JetBrains.Annotations;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Atomic.Entities
{
    //TODO: Написать свой инспектор без Odin!
    [UsedImplicitly]
    public class EntityDrawer : OdinValueDrawer<Entity>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            Entity entity = this.ValueEntry.SmartValue;

            SirenixEditorGUI.BeginBox($"{entity.Name}");
            {
                EditorGUILayout.LabelField("Tags:", EditorStyles.boldLabel);
                foreach (int key in entity.Tags)
                    EditorGUILayout.LabelField($"{EntityUtils.IdToName(key)}");
                
                EditorGUILayout.Space(12);
                EditorGUILayout.LabelField("Values:", EditorStyles.boldLabel);
                foreach ((int key, object value) in entity.Values)
                    EditorGUILayout.LabelField($"{EntityUtils.IdToName(key)}: {value}");
                
                EditorGUILayout.Space(12);
                EditorGUILayout.LabelField("Behaviours:", EditorStyles.boldLabel);
                foreach (var b in entity.Behaviours)
                    EditorGUILayout.LabelField($"{b.GetType().Name}");
            }
            SirenixEditorGUI.EndBox();
        }
    }
}
#endif