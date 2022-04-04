using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AbillityAttribute))]
public class BulletAbillity : PropertyDrawer
{
    [Header("Level")]
    public int Level;
    [Header("Bullet")]
    public int BulletNum;
    public float BulletPower;
    public float ShotRate;

}
