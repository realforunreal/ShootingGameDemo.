using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHp;
    [SerializeField] float hp;

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentHp = hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            currentHp -= GameManager.instance.p_BulletSet.bulletPower;
            Destroy(collision.gameObject);
            if (currentHp <= 0)
            {
                GameManager.instance.itemManager.currentLootEnergy += 2.0f;
                Destroy(gameObject);
            }
        }
    }
}
