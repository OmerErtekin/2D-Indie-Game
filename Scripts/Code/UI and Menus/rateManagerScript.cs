using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class rateManagerScript : Singleton<rateManagerScript>
{

    [SerializeField]
    private rateBoxScript rateBoxScript;

    int countToRate = 5;

    [HideInInspector]
    public int playCount;

    [HideInInspector]
    public bool rateOff = false;

    public void ClickPlay()
    {
        playCount++;
        Debug.Log("playcount "+playCount);

        if (playCount > PlayerPrefs.GetInt("playCount"))
        {
            PlayerPrefs.SetInt("playCount", playCount);
        }
        else
        {
            PlayerPrefs.SetInt("playCount", PlayerPrefs.GetInt("playCount")+1);
        }

        Debug.Log("count: "+ PlayerPrefs.GetInt("playCount"));

        if (PlayerPrefs.GetInt("playCount") % countToRate == 0 && !rateOff && PlayerPrefs.GetInt("rate") != 1)
        {
            Debug.Log("4");
#if UNITY_IOS
            Debug.LogWarning("IOS");
            Device.RequestStoreReview();
#else
            rateBoxScript.gameObject.SetActive(true);
            #endif
            PlayerPrefs.SetInt("rate", 1);
        }
    }

    public void ClickPlayTwo()
    {
        playCount += 5;

        if (playCount % countToRate == 0 && !rateOff && PlayerPrefs.GetInt("rate") != 1)
        {
            #if UNITY_IOS
            Debug.LogWarning("IOS");
            Device.RequestStoreReview();
            #else
            rateBoxScript.gameObject.SetActive(true);
            #endif
            PlayerPrefs.SetInt("rate", 1);

        }
    }
}
