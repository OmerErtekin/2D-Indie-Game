using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectTexture : MonoBehaviour
{

    public Sprite[] textures;

    public GameObject[] button;

    public GameObject gameMenuPanel;

    int panelCloseCntr = 0;

    void Start()
    {
        //PlayerPrefs.SetInt("texture", 1);
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void buttoncntr (int buttonCounter)
    {
        if (buttonCounter == 0)
        {
           
            panelCloseCntr++;
            if (panelCloseCntr == 1)
            {
                for (int i = 0; i < button.Length; i++)
                {
                    button[i].SetActive(true);
                }
            }
            if (panelCloseCntr == 2)
            {
                for (int i = 0; i < textures.Length; i++)
                {
                    button[i].SetActive(false);
                }
                panelCloseCntr = 0;
            }
        }

        if (buttonCounter == 1)
        {
            gameMenuPanel.GetComponent < Image >().sprite = textures[buttonCounter-1];
            PlayerPrefs.SetInt("texture",buttonCounter);
        }

        if (buttonCounter == 2)
        {
            gameMenuPanel.GetComponent<Image>().sprite = textures[buttonCounter - 1];
            PlayerPrefs.SetInt("texture", buttonCounter);

        }

        if (buttonCounter == 3)
        {
            gameMenuPanel.GetComponent<Image>().sprite = textures[buttonCounter - 1];
            PlayerPrefs.SetInt("texture", buttonCounter);

        }

        /*if (buttonCounter == 4)
        {
            gameMenuPanel.GetComponent<Image>().sprite = textures[buttonCounter - 1];
            PlayerPrefs.SetInt("texture", buttonCounter);

        }*/

    }
}
