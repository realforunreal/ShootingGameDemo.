using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ForceInterfaceAttribute))]
public class ForcePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if(property.propertyType == SerializedPropertyType.ObjectReference){
            ForceInterfaceAttribute forceAttribute = (ForceInterfaceAttribute)attribute;
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            Object obj = EditorGUI.ObjectField(position, label,
                property.objectReferenceValue, forceAttribute.interfaceType, //프로퍼티 타입
                !EditorUtility.IsPersistent(property.serializedObject.targetObject));    //선택된 개체가 씬/에셋에 존재하는지
            if (EditorGUI.EndChangeCheck())
            {
                if (obj == null)
                {
                    property.objectReferenceValue = null;
                }
                else if (forceAttribute.interfaceType.IsAssignableFrom(obj.GetType()))
                {
                    property.objectReferenceValue = obj;
                }
                else if (obj is GameObject)
                {
                    MonoBehaviour component = (MonoBehaviour)((GameObject)obj).GetComponent(forceAttribute.interfaceType);
                    if (component != null)
                    {
                        property.objectReferenceValue = component;
                    }
                }
            }
            
            EditorGUI.EndProperty();
        }
        else
        {
            EditorGUI.LabelField(position, "Use ForceInterfaceAttribute on Object");
        }
    }
}
