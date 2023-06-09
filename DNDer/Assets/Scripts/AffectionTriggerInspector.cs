using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LoverScript))]
public class YourCharacterClassEditor : Editor
{
    private SerializedProperty triggers;
    private void OnEnable()
    {
        triggers = serializedObject.FindProperty("triggers");
    }

    public override void OnInspectorGUI()
    {
        //serializedObject.Update();

        //EditorGUILayout.PropertyField(triggers, true);

        //serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}
