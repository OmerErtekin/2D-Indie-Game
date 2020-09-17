using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rateBoxScript : MonoBehaviour
{
    public void rate(int cntr)
    {
        if(cntr == 0) //no
        {
            rateManagerScript.Instance.rateOff = true;
            PlayerPrefs.SetInt("rate", 1);
            gameObject.SetActive(false);
            Debug.Log("2");
        }

        if (cntr == 1) //later
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            PlayerPrefs.SetInt("rate", 0);
        }

        if (cntr == 2) // yep
        {
            Application.OpenURL("market://details?id=com.PictaGames.Knocker");
            rateManagerScript.Instance.rateOff = true;
            //PlayerPrefs.SetInt("rate", 1);
            gameObject.SetActive(false);
            Debug.Log("1");
        }
    }

}
