using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StatData))]
public class StatDataEditor : Editor
{
    Vector2 scroll;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        StatData data = (StatData)target;//��Xinspector�W���ؼ�

        scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.MaxHeight(300));

        for(int i = 1; i < 100; i++)
        {
            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("Level" + (i));
            EditorGUILayout.LabelField((int)data.xpCurve.Evaluate(i) + "xp");
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();
    }
}
