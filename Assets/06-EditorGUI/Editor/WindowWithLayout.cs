using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class WindowWithLayout : EditorWindow {
    [MenuItem("Window/Layout examples")]
    static void Init() {
        WindowWithLayout window = (WindowWithLayout)EditorWindow.GetWindow(typeof (WindowWithLayout));
        window.Show();
    }

    string someText = "text field example";
    bool toggleGroupExample;
    bool toggle1;
    bool toggle2;
    bool toggle3;

    bool foldout;

    // One of the "pearls" in Unity API, FadeGroup. It requires "AnimBool" which is float in fact and keeps progress of folding or unfolding.
    // FadeGroup also requires to subscribe on valueChanged and call Repaint. For animations sake.
    // However there is also Foldout which seems more useful.
    AnimBool fadeGroupHandler = new AnimBool(true);
    void OnEnable() {
        fadeGroupHandler.valueChanged.AddListener(Repaint);
    }

    PrimitiveType primitiveType;

    void OnGUI() {
        EditorGUILayout.LabelField("Examples");

        someText = EditorGUILayout.TextField(someText);

        toggleGroupExample = EditorGUILayout.BeginToggleGroup("Togle example", toggleGroupExample);
        EditorGUILayout.LabelField("Picaboo!");
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.LabelField("Horizontal group!");
        EditorGUILayout.BeginHorizontal();
        GUILayout.Button("One");
        GUILayout.Button("Two");
        GUILayout.Button("Tree");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Vertical group!");
        EditorGUILayout.BeginVertical();
        GUILayout.Button("One");
        GUILayout.Button("Two");
        GUILayout.Button("Tree");
        EditorGUILayout.EndVertical();

        EditorGUILayout.Separator();

        fadeGroupHandler.target = EditorGUILayout.ToggleLeft("Folding group", fadeGroupHandler.target);
        if (EditorGUILayout.BeginFadeGroup(fadeGroupHandler.faded)) {
            EditorGUILayout.BeginHorizontal(); // Indenting GUI controls through "table" layout
            GUILayout.Space(20);

            EditorGUILayout.BeginVertical();
            toggle1 = GUILayout.Toggle(toggle1, "Toggle 1");
            toggle2 = GUILayout.Toggle(toggle2, "Toggle 2");
            toggle3 = GUILayout.Toggle(toggle3, "Toggle 3");
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndFadeGroup();

        EditorGUILayout.Separator();

        foldout = EditorGUILayout.Foldout(foldout, "Foldout group");
        if (foldout) {
            var indent = EditorGUI.indentLevel; // Uou can use indentLevel for indenting fields
            EditorGUI.indentLevel = 1;

            EditorGUILayout.BeginVertical();
            EditorGUILayout.Vector3Field("", Vector3.zero);
            EditorGUILayout.TextField("Text field", "Not editable text");
            EditorGUILayout.TextField("Text field", "Not editable text");
            EditorGUILayout.EndVertical();

            EditorGUI.indentLevel = indent;
        }

        EditorGUILayout.Separator();

        primitiveType = (PrimitiveType) EditorGUILayout.EnumMaskField("Bit mask chooser", primitiveType);


        EditorGUILayout.HelpBox("Information box", MessageType.Info);

        if (GUILayout.Button("Handled button")) {
            Debug.Log("Button clicked");
        }
    }
}
