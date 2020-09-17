using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteStainCode : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;

    float timer = 0;
    float a;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        timer += Time.deltaTime;
        a = 1 / timer;
        SpriteRenderer.color = new Color(255, 255, 255, a);

        if (SpriteRenderer.color.a < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
