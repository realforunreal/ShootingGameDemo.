using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName ="Data/Item Function")]
public class ItemFunction : ScriptableObject
{
    public enum Item_State { BulletShotTIme, BulletNumber}
    public enum Bullet_State { None, InitWay, Multiple}
    public Item_State item_State;
    public Bullet_State bullet_State;
    public float value;
}
