using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScroll : MonoBehaviour
{
    public float scrolSpeed;
    public SpriteRenderer renderer;

    private void Start()
    {

    }

    private void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(0f, -scrolSpeed * Time.deltaTime);
    }
}
