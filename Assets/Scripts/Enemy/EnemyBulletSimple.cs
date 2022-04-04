using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSimple : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletPower;
    Vector3 dir;

    private void Start()
    {
        dir = GameManager.instance.player.transform.position - transform.position;
        dir.Normalize();
    }
    private void Update()
    {
        transform.position += dir * Time.deltaTime * bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer  == 10)
        {
            GameManager.instance.p_Hp -= bulletPower;
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
