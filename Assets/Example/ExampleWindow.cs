using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    string myString = "Hello";

    [MenuItem("Window/Example")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Example");
    }

    private void OnGUI()
    {
        GUILayout.Label("This is a label.", EditorStyles.boldLabel);

        EditorGUILayout.TextField("Name", myString);
    }
}
