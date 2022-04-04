using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Abillity_Type { BulletSet, Player, Coin }

[CreateAssetMenu(menuName ="Data/Abillity/Function")]
public class AbillityFunction : ScriptableObject
{
    public Abillity_Type myType;

    public float abc;

    //BulletSet에 영향을 미치는 어빌리티
    //PlayerMove에 영향을 미치는 어빌리티
    //게임 내 재화에 영향을 미치는 어빌리티
}
