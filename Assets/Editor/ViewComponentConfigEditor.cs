using UnityEditor;

[CustomEditor(typeof(ViewComponentConfig))]
public class ViewComponentConfigEditor : Editor
{
    SerializedProperty actions;

    void OnEnable() {
        actions = serializedObject.FindProperty("actions");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(actions);
        serializedObject.ApplyModifiedProperties();
    }
}
