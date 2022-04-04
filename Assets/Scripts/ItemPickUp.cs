using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    public Pilot item;
    public ItemFunction function;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            if (function.item_State == ItemFunction.Item_State.BulletShotTIme)
            {
                GameManager.instance.p_BulletSet.bulletShotTime += function.value;
                Destroy(gameObject);
            }
            else if(function.item_State == ItemFunction.Item_State.BulletNumber)
            {
                GameManager.instance.p_BulletSet.bulletNumber += (int)function.value;
                if(GameManager.instance.p_BulletSet.bulletNumber %2 == 0) {
                    GameManager.instance.p_BulletSet.bulletTheta /= 2;
                }
                else
                {
                    GameManager.instance.p_BulletSet.bulletTheta *= 2;
                }
                Destroy(gameObject);
            }
            if(function.bullet_State == ItemFunction.Bullet_State.InitWay)
            {
                GameManager.instance.p_BulletSet.bullet_state = BulletSet.Bullet_State.InitWay;
            }
            else if(function.bullet_State == ItemFunction.Bullet_State.Multiple)
            {
                GameManager.instance.p_BulletSet.bullet_state = BulletSet.Bullet_State.Multiple;
            }
        }
    }

}
