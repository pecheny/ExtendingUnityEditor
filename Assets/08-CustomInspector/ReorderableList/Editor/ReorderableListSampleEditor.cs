using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(ReorderableListSample))]
public class ReorderableListSampleEditor : Editor {
    private ReorderableList list;

    private void OnEnable() {
        list = new ReorderableList(serializedObject,
                serializedObject.FindProperty("list"),
                true, true, true, true);
        list.drawElementCallback = DrawElementCallback;
        list.elementHeightCallback = ElementHeightCallback;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused) {
        var element = list.serializedProperty.GetArrayElementAtIndex(index);
        rect.x += 10;
        rect.width -= 10;
        EditorGUI.PropertyField(rect, element, true);
    }

    float ElementHeightCallback(int index) {
        var element = list.serializedProperty.GetArrayElementAtIndex(index);
        return EditorGUI.GetPropertyHeight(element);
    }
}
