using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public GameObject panel;
    int pauseButtonCounter = 0;
    public Sprite[] pauseButtonSprite;
    public GameObject pauseButtonObject;

    public Sprite[] textures;
    public GameObject background;
    void Start()
    {
        panel.SetActive(false);
        if (PlayerPrefs.GetFloat("r") == 0 || PlayerPrefs.GetFloat("g") == 0 || PlayerPrefs.GetFloat("b") == 0)
        {
            background.GetComponent<SpriteRenderer>().color = new Vector4(164, 154, 154, 1);
        }
        else
        {
            background.GetComponent<SpriteRenderer>().color = new Vector4(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"), 1);
        }

        //Debug.Log(PlayerPrefs.GetInt("texture"));
        
        if (PlayerPrefs.GetInt("texture") == 0)
        {
            PlayerPrefs.SetInt("texture", 1);
        }
        if(PlayerPrefs.GetInt("texture") == 1 || PlayerPrefs.GetInt("texture") == 0)
        {
            background.transform.localScale = new Vector3(1.9f,1.5f,1);
        }
        if(PlayerPrefs.GetInt("texture") == 2)
        {
            background.transform.localScale = new Vector3(0.4f, 0.3f, 1);
        }
        background.GetComponent<SpriteRenderer>().sprite = textures[PlayerPrefs.GetInt("texture")-1];

    }

    void Update()
    {
        
    }

    public void pauseButton(int i)
    {
        if (i == 0)
        {
            pauseButtonCounter++;
            if (pauseButtonCounter == 1)
            {
                panel.SetActive(true);
                pauseButtonObject.GetComponent<Image>().sprite = pauseButtonSprite[pauseButtonCounter - 1];
                Time.timeScale = 0;

            }
            if (pauseButtonCounter == 2)
            {
                panel.SetActive(false);
                pauseButtonObject.GetComponent<Image>().sprite = pauseButtonSprite[pauseButtonCounter - 1];
                pauseButtonCounter = 0;
                Time.timeScale = 1;
            }
        }

        if(i == 1)
        {
            SceneManager.LoadScene(0);
            knocker.newEnemyCount = 0;
            Time.timeScale = 1;

        }
        if (i == 2)
        {
            SceneManager.LoadScene(1);
            knocker.newEnemyCount = 0;
            Time.timeScale = 1;

        }
    }
}
