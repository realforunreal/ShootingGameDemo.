using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    public float shotTime;

    public GameObject bullet;

    public Vector3 toPos;
    [SerializeField] float setPosSpeed;

    float t;

    private void Start()
    {

    }

    private void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, toPos, t * setPosSpeed);
        

        if (t>= shotTime)
        {
            t = 0;
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
    

}
