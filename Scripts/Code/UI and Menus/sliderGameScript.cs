using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderGameScript : MonoBehaviour
{
    public Slider slider;
    public AudioSource[] audioSources;
    public Button music;
    public int spriteCounter = 0;
    float volumeMother = 35;

    public Sprite[] mscSprt;

    public void SetSlidervalue()
    {
        float volume = (slider.GetComponent<Slider>().value);
        volumeMother = volume;
        for (int i = 0; i < audioSources.Length ; i++)
        {
            if (i == 0)
            {
                audioSources[i].volume = (volume / 70);

            }
            else
            {
                if(i == 1)
                {
                    audioSources[i].volume = (volume / 100) * 2.25f;

                }
                else
                {
                    audioSources[i].volume = (volume / 100) * 2.8f;

                }
            }
        }
    }
    public void volumeZero()
    {
        spriteCounter++;

        if(spriteCounter == 1)
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = 0;
            }
            slider.interactable = false;
            music.GetComponent<Image>().sprite = mscSprt[1];
            music.GetComponent<Image>().color = new Vector4(0.6f, 0.35f, 0.15f, 0.7f);

        }

        if (spriteCounter == 2)
        {
            spriteCounter = 0;
            slider.interactable = true;
            music.GetComponent<Image>().sprite = mscSprt[0];
            music.GetComponent<Image>().color = new Vector4(0.6f, 0.35f, 0.15f, 1);

            for (int i = 0; i < audioSources.Length; i++)
            {
                if (i == 0)
                {
                    audioSources[i].volume = (volumeMother / 70);

                }
                else
                {
                    if (i == 1)
                    {
                        audioSources[i].volume = (volumeMother / 100) * 2.25f;

                    }
                    else
                    {
                        audioSources[i].volume = (volumeMother / 100) * 2.8f;

                    }
                }
            }
        }

    }

}
