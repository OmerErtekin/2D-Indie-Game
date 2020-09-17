using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class characterCreator : MonoBehaviour
{
    CheckNickName nickScript;
    //name Input Field

    public InputField nameField; // public bir input objesi aldık

    public Text nickName;

    public Text warning;

    public Text contol;

    //User name string
    private string charName;
    private bool isNameTaken;


    void Start()
    {
        isNameTaken = false;
        nickScript = GetComponent<CheckNickName>();
        warning.enabled = false;
        gameObject.SetActive(true);
        nickScript.DownloadHighScore();
        if (PlayerPrefs.GetInt("input") == 1)
        {
            gameObject.SetActive(false);
        }
        
    }

    void textController()
    {
        if (nickName.text.Length >= 3)
        {
            contol.enabled = true;
            isNameTaken = false;
            charName = nameField.text;
            warning.enabled = false;
            StartCoroutine(CheckTheNick());
            // isim id degisimi burda yapılacak
            //---------------------------------
        }
        if (nickName.text.Length < 3)
        {
            warning.enabled = true;
            contol.enabled = false;
        }


    }

    public void OnSubmit()
    {
        // set charName string to text in namefield
        textController();
        //degisim
    }

    public bool IsNickTaken(CheckNickName.Highscore1[] playerList)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if (string.Equals(charName, playerList[i].username))
            {
                isNameTaken = true;
                if (PlayerPrefs.GetInt("language") == 1)
                {
                    contol.text = "This name is already taken.";

                }
                else if (PlayerPrefs.GetInt("language") == 2)
                {
                    contol.text = "Ce nom a été déjà pris.";

                }
                else
                {
                    contol.text = "Bu ad zaten alınmış.";

                }
               
            }
        }
        return isNameTaken;

    }


    IEnumerator CheckTheNick()
    {
        if (PlayerPrefs.GetInt("language") == 1)
        {
            contol.text = "The nickname is being checked.";
        }
        else if (PlayerPrefs.GetInt("language") == 2)
        {
            contol.text = "Le surnom est en cours de vérification.";
        }
        else
        {
            contol.text = "Takma ad kontrol ediliyor.";
        }

        yield return new WaitForSeconds(1);
        if (nickScript.isNickTaken == false)
        {
            PlayerPrefs.SetInt("input", 1);
            PlayerPrefs.SetString("PlayerID", charName);
            gameObject.SetActive(false);
            Debug.Log("nick koydu");
        }
        else
        {
            if (PlayerPrefs.GetInt("language") == 1)
            {
                contol.text = "Nickname suitable.";
            }
            else if (PlayerPrefs.GetInt("language") == 2)
            {
                contol.text = "Surnom convenable.";
            }
            else
            {
                contol.text = "Takma ad uygun.";
            }
        }


    }
}
