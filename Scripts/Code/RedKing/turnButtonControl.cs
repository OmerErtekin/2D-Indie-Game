using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnButtonControl : MonoBehaviour
{
    public GameObject button;
    SpriteRenderer Image;
    float time = 0;
    private float a;
    int cntr = 0;
    void Start()
    {
        Image = button.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time < 3 && cntr < 2)
        {
            a = 1 / 1.5f * time;
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, a);
        }
        else 
        {
            Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, 0);
            cntr++;
            time = 0;
        } 
        if(cntr > 2)
        {
            this.enabled = false;
        }
    }
}
