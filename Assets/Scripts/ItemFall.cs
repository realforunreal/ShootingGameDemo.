using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFall : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.position -= Vector3.down * Time.deltaTime * speed;
    }
}
