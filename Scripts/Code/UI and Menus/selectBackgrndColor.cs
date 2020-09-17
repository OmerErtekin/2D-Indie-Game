using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class selectBackgrndColor : MonoBehaviour
{
    Vector4 color;

    float r;
    float g;
    float b;
    float a;

    int closeButton = 0;
    int closeButtonTexture = 0;
    int closeButtonSlider = 0;

    public static Vector4 backgroundColor;

    public GameObject[] colors;
    public GameObject actifColor;

    public GameObject cmr;

    public GameObject[] texture;

    public GameObject[] slider;

    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].SetActive(false);
        }
        for(int j = 0; j<texture.Length; j++)
        {
            texture[j].SetActive(false);
        }
        for (int j = 0; j < slider.Length; j++)
        {
            slider[j].SetActive(false);
        }


    }

    void Selectcolor(int cntr)
    {
        r = colors[cntr - 1].GetComponent<Image>().color.r;
        g = colors[cntr - 1].GetComponent<Image>().color.g;
        b = colors[cntr - 1].GetComponent<Image>().color.b;

        PlayerPrefs.SetFloat("r", r);
        PlayerPrefs.SetFloat("g", g);
        PlayerPrefs.SetFloat("b", b);




        backgroundColor = new Vector4(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"), 1);

        actifColor.GetComponent<Image>().color = backgroundColor;

        cmr.GetComponent<Image>().color = backgroundColor;
    }

    public void Selected(int cntr)
    {
        if (cntr == 0)
        {
            closeButton++;
            closeButtonTexture = 0;
            closeButtonSlider = 0;
            if (closeButton == 1)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].SetActive(true);
                }
                for (int j = 0; j < texture.Length; j++)
                {
                    texture[j].SetActive(false);
                }
                for (int j = 0; j < slider.Length; j++)
                {
                    if (j == 0)
                    {
                        PlayerPrefs.SetFloat("music", slider[0].GetComponent<Slider>().value);
                    }
                    if (j == 1)
                    {
                        PlayerPrefs.SetFloat("musicTwo", slider[1].GetComponent<Slider>().value);
                    }
                    slider[j].SetActive(false);
                }
            }

            if (closeButton == 2)
            {
                closeButton = 0;
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].SetActive(false);
                }

            }
         

        }

        if (cntr == 1)
        {
            Selectcolor(cntr);
        }

        if (cntr == 2)
        {
            Selectcolor(cntr);
        }

        if (cntr == 3)
        {
            Selectcolor(cntr);
        }

        if (cntr == 4)
        {
            Selectcolor(cntr);
        }

        //yeni scripte acmak isi cok karistiracakti buraya yaziyorum select texture kodunu
        if(cntr == 5)
        {
            closeButtonTexture++;
            closeButton = 0;
            closeButtonSlider = 0;
            if (closeButtonTexture == 1)
            {
                for (int j = 0; j < texture.Length; j++)
                {
                    texture[j].SetActive(true);
                }
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].SetActive(false);
                }
                for (int j = 0; j < slider.Length; j++)
                {
                    slider[j].SetActive(false);
                    if (j == 0)
                    {
                        PlayerPrefs.SetFloat("music", slider[0].GetComponent<Slider>().value);
                    }
                    if (j == 1)
                    {
                        PlayerPrefs.SetFloat("musicTwo", slider[1].GetComponent<Slider>().value);
                    }
                }
                
            }

            if (closeButtonTexture == 2)
            {
                closeButtonTexture = 0;
                for (int j = 0; j < texture.Length; j++)
                {
                    texture[j].SetActive(false);
                }
            }
        }

        if (cntr == 6)
        {
            closeButtonSlider++;
            closeButton = 0;
            closeButtonTexture = 0;
            if (closeButtonSlider == 1)
            {
                for (int j = 0; j < slider.Length; j++)
                {
                    slider[j].SetActive(true);
                }
                for (int j = 0; j < texture.Length; j++)
                {
                    texture[j].SetActive(false);
                }
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].SetActive(false);
                }
            }

            if (closeButtonSlider == 2)
            {
                closeButtonSlider = 0;
                for (int j = 0; j < slider.Length; j++)
                {
                    slider[j].SetActive(false);
                    if (j == 0)
                    {
                        PlayerPrefs.SetFloat("music", slider[0].GetComponent<Slider>().value);
                    }
                    if (j == 1)
                    {
                        PlayerPrefs.SetFloat("musicTwo", slider[1].GetComponent<Slider>().value);
                    }
                }
            }

        }

    }
}
