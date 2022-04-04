using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    GameObject Enemy;
    [SerializeField] 
    float spawnTime;
    [SerializeField] 
    Vector2 spawnYrange;

    [SerializeField]
    int enemyStage;

    [SerializeField]
    List<EnemyData> enemyData;

    private GameManager gamemanager;

    float t;

    private void Start()
    {
        gamemanager = GameManager.instance;
        gamemanager.spawner = this;
    }
    private void FixedUpdate()
    {
        Spawn();
    }
    void Spawn()
    {
        t += Time.deltaTime;
        if (t >= spawnTime)
        {
            enemyStage++;
            Vector3 toPos = new Vector3(Random.Range(gamemanager.camera_zero.x, 
            gamemanager.camera_top.x),Random.Range(spawnYrange.x, spawnYrange.y), 0);
            GameObject newobj = Instantiate(Enemy, new Vector3(toPos.x, transform.position.y, 0), Quaternion.identity);
            EnemySimple ens = newobj.GetComponent<EnemySimple>();
            ens.toPos = toPos;

            t = 0;
        }
    }
}
