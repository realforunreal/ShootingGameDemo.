using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName =("Data/EnemyData"))]
public class EnemyData : ScriptableObject
{
    public GameObject prefab;
    [SerializeField]
    private float spawnStage;
    public float spawnTime;
    public float damage;
    public float hp;
}
