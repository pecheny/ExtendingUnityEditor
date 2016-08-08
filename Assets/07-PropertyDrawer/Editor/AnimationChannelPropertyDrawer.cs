using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(AnimationChannel))]
[CanEditMultipleObjects]
public class AnimationChannelPropertyDrawer : PropertyDrawer{
    static Dictionary<Type, FieldInfo> cache = new Dictionary<Type, FieldInfo>();
    FieldInfo GetField(Type t, string propName) {
        if (cache.ContainsKey(t)) {
            return cache[t];
        }
        FieldInfo fields = t.GetField(propName);
        cache[t] = fields;
        return fields;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        var targetObjects = property.serializedObject.targetObjects;
        var target = property.serializedObject.targetObject;
        var field = GetField(target.GetType(), property.name);
        AnimationChannel val = (AnimationChannel) field.GetValue(target);
        val = (AnimationChannel) EditorGUI.EnumMaskField(position, "Animation channels", val);
        for (int i = 0; i < targetObjects.Length; i++ ) {
            target = targetObjects[i];
            field.SetValue(target, val);
        }
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
