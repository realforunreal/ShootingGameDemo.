using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float x, y;
    public float vx, vy;
    GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameManager.instance.player;
        x = transform.position.x;
        y = transform.position.y;
        //transform.rotation = new Vector3(0,0,)
    }

    void Update()
    {
        //transform.Translate(new Vector3(vx, vy, 0));

        x += vx;
        y += vy;
        //transform.SetPositionAndRotation(new Vector2(x - 0.1f, y), Quaternion.identity);
        transform.position = new Vector2(x-0.1f , y);
    }

    void OnBecameInvisible()//오브젝트가 보이지 않게 되면
    {
        Destroy(gameObject);
    }
}
