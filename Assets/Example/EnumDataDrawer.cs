﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(EnumDataAttribute))]
public class EnumDataDrawer : PropertyDrawer
{
    SerializedProperty array;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
    {
        EnumDataAttribute enumData = (EnumDataAttribute)attribute;
        string path = property.propertyPath;
        if(array == null)
        {
            array = property.serializedObject.FindProperty(path.Substring(0, path.LastIndexOf('.')));
            if (array == null)
            {
                EditorGUI.LabelField(position, "Use EnumDataAttribute on arrays");
                return;
            }
        }
        
        if(array.arraySize != enumData.names.Length)    //배열 길이와 리스트의 길이를 비교해서 다르면 맞춰줌
        {
            array.arraySize = enumData.names.Length;
        }
        int index = System.Convert.ToInt32(path.Substring(path.IndexOf('[')+1).Replace("]", ""));
        label.text = enumData.names[index];
        EditorGUI.PropertyField(position, property, label, true);
    }
}
