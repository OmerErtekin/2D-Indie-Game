using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class gameMenu : MonoBehaviour
{
    public Text hignhScoreText;
    public static int scoreCntr;

    private InterstitialAdScript interAdScript;
    
    public GameObject panel; //option
    int panelCloseCntr = 0;

    public GameObject Background;
    public GameObject motherColorButton;

    public Sprite[] textures;

    public GameObject[] scorePanels;
    public GameObject[] infoPanels;
    int scorePanelsCntr = 0;

    public GameObject frontButton;
    public GameObject backButton;
    public GameObject containeMother;
    public GameObject containerInfo;

    public GameObject rateBox;

    public Slider slider;
    public Slider sliderTwo;

    public GameObject translate;
    void Start()
    {
        interAdScript = GameObject.Find("InterstitialAdObject").GetComponent<InterstitialAdScript>();
        hignhScoreText.text = "En Yüksek Skor: " + PlayerPrefs.GetInt("high");
        panel.SetActive(false);
        //eger renk seceneklerinde birinci renk degisirse renk kodu buraya elle girilmeli
        if (PlayerPrefs.GetFloat("r") == 0 || PlayerPrefs.GetFloat("g") == 0 || PlayerPrefs.GetFloat("b") == 0)
        {
            Background.GetComponent<Image>().color = new Vector4(164,154,154,1);
            motherColorButton.GetComponent<Image>().color = new Vector4(164, 154, 154, 1);
        }
        else
        {
            Background.GetComponent<Image>().color = new Vector4(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"), 1);
            motherColorButton.GetComponent<Image>().color = new Vector4(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"), 1);
        }
        //Debug.Log("A"+PlayerPrefs.GetInt("texture"));


        if (PlayerPrefs.GetInt("texture") == 0)
        {
            PlayerPrefs.SetInt("texture", 1);
        }
        Background.GetComponent<Image>().sprite = textures[PlayerPrefs.GetInt("texture") - 1];

        frontButton.SetActive(true);
        backButton.SetActive(false);

        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("music");
        sliderTwo.GetComponent<Slider>().value = PlayerPrefs.GetFloat("musicTwo");

        translate.GetComponent<translateMotor>().translator();
        //PlayerPrefs.DeleteAll();


    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("PlayerDontWatchTheAds") >= 4)
        {
            interAdScript.ShowInterstitialAd();
        }
    }
    public void button(int i)
    {
        if(i == 0)
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetFloat("music", slider.GetComponent<Slider>().value);
            PlayerPrefs.SetFloat("musicTwo", sliderTwo.GetComponent<Slider>().value);
        }

        if (i == 1)
        {
            panelCloseCntr++;
            if (panelCloseCntr == 1)
            {
                panel.SetActive(true);
            }
            if (panelCloseCntr == 2)
            {
                panel.SetActive(false);
                panelCloseCntr = 0;
                PlayerPrefs.SetFloat("music", slider.GetComponent<Slider>().value);
                PlayerPrefs.SetFloat("musicTwo", sliderTwo.GetComponent<Slider>().value);
            }
        }

        if(i == 2)
        {
            //front
            scorePanelsCntr++;
            //Debug.Log("int_1 " + scorePanelsCntr);
            if (scorePanelsCntr > 0) 
            {
                backButton.SetActive(true);
            }
            else
            {
                backButton.SetActive(false);
            }
            
            if(scorePanelsCntr == 2)
            {
                frontButton.SetActive(false);
            }

            for(int j = 0; j < scorePanels.Length; j++)
            {
                scorePanels[j].SetActive(false);
            }
            scorePanels[scorePanelsCntr].SetActive(true);
            containeMother.GetComponent<ScrollRect>().content = scorePanels[scorePanelsCntr].GetComponent<RectTransform>();
            if (scorePanelsCntr == 2)
            {
                scorePanelsCntr = -1;
            }
        }

        if (i == 3)
        {
            //back

            if (scorePanelsCntr == 0)
            {
                backButton.SetActive(false);
                scorePanelsCntr = 1;
            }

            if (scorePanelsCntr == -1)
            {
                backButton.SetActive(false);
                scorePanelsCntr = 2;
            }

            //Debug.Log("int "+scorePanelsCntr);

            if(scorePanelsCntr == 1 || scorePanelsCntr == 2)
            {
                backButton.SetActive(false);
                frontButton.SetActive(true);
            }
            scorePanelsCntr--;
            if (scorePanelsCntr > 0)
            {
                backButton.SetActive(true);
            }


            for (int j = 0; j < scorePanels.Length; j++)
            {
                scorePanels[j].SetActive(false);
            }
            scorePanels[scorePanelsCntr].SetActive(true);
            containeMother.GetComponent<ScrollRect>().content = scorePanels[scorePanelsCntr].GetComponent<RectTransform>();
           
        }

    }

    public void infoPanel(int counter)
    {

        //1. front
        if (counter == 1)
        {
            for (int i = 0; i < infoPanels.Length; i++)
            {
                infoPanels[i].SetActive(false);
            }
            infoPanels[counter].SetActive(true);
            containerInfo.GetComponent<ScrollRect>().content = infoPanels[counter].GetComponent<RectTransform>();
        }
        //2.front
        if (counter == 2)
        {
            //Debug.Log("tıklandı");
            for (int i = 0; i < infoPanels.Length; i++)
            {
                infoPanels[i].SetActive(false);
            }
            infoPanels[counter].SetActive(true);
            containerInfo.GetComponent<ScrollRect>().content = infoPanels[counter].GetComponent<RectTransform>();
        }
        //1.back
        if (counter == 3)
        {
            for (int i = 0; i < infoPanels.Length; i++)
            {
                infoPanels[i].SetActive(false);
            }
            infoPanels[0].SetActive(true);
            containerInfo.GetComponent<ScrollRect>().content = infoPanels[0].GetComponent<RectTransform>();
        }

        //2.back
        if (counter == 4)
        {
            for (int i = 0; i < infoPanels.Length; i++)
            {
                infoPanels[i].SetActive(false);
            }
            infoPanels[1].SetActive(true);
            containerInfo.GetComponent<ScrollRect>().content = infoPanels[1].GetComponent<RectTransform>();
        }
    }

    public void rateInfoButton(int rate)
    {
        if (rate == 0)
        {
            PlayerPrefs.GetInt("rate", 0);

            Application.OpenURL("market://details?id=com.PicaGames.Knocker");
            rateManagerScript.Instance.rateOff = true;
            PlayerPrefs.SetInt("rate", 1);
            rateBox.SetActive(false);
        }
    }

}
