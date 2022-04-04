using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbillityFunction))]
public class AbillityFunctionEditor : Editor
{
    Abillity_Type type;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AbillityFunction function = (AbillityFunction)target;
        type = function.myType;
        
        switch (type)
        {
            case Abillity_Type.BulletSet:
                GUILayout.Label("BulletSet");
                return;
            case Abillity_Type.Player:
                GUILayout.Label("Player");
                return;
            case Abillity_Type.Coin:
                GUILayout.Label("Coin");
                return;
        }
    }
}
