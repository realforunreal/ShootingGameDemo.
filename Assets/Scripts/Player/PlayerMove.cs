using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { IDLE, ABSOL }

public class PlayerMove : MonoBehaviour
{
    public PlayerState p_State = PlayerState.IDLE;

    public SpriteRenderer p_sprite;

    [SerializeField]
    float speed;
    [SerializeField]
    float absolTIme;

    GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;
        manager.player = this.gameObject;
        manager.itemManager.enabled = true;
        manager.gameObject.GetComponent<UIManager>().enabled = true;
    }

    void FixedUpdate()
    {
        Move();
    }

    private IEnumerator Absol(float absolTime)
    {
        p_State = PlayerState.ABSOL;
        Debug.Log("Absol");
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
        float currentTime = 0;
        p_sprite.color /= 2;
        while(currentTime <= absolTime)
        {
            currentTime += Time.deltaTime;
            if(currentTime>= absolTime)
            {
                p_sprite.color *= 2;
                col.isTrigger = false;
                p_State = PlayerState.IDLE;
                Debug.Log("IDLE");
                yield return null;
            }
            yield return null;
        }
    }
    Vector3 Dir()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector3(x, y, 0);
    }

    
    private void Move()
    {
        transform.position += Dir() * Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 
            manager.camera_zero.x, manager.camera_top.x),
           Mathf.Clamp(transform.position.y, manager.camera_zero.y,
           manager.camera_top.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9 && p_State != PlayerState.ABSOL)
        {
            StartCoroutine(Absol(absolTIme));
        }
    }
}
