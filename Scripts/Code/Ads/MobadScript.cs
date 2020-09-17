using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class MobadScript : MonoBehaviour
{
    private RewardBasedVideoAd rewardedAd;
    private string rewardedID;
    private string appID;
    private int playerAdCount;
    private RedKing kingScript;
    private GameOverCode gameOverScript;
    public int adState;
    public bool isAdLoaded;
    void Start()
    {

        gameOverScript = GameObject.Find("GameOver").GetComponent<GameOverCode>();
        kingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<RedKing>();
        adState = 0;
        appID = "ca-app-pub-3934768444739338~3058468135";
        rewardedID = "ca-app-pub-3934768444739338/6806141454";
        // TEST ID : "ca-app-pub-3940256099942544/5224354917";
        // Gerçek ID: ca-app-pub-3934768444739338/6806141454
        rewardedAd = RewardBasedVideoAd.Instance;
        MobileAds.Initialize(appID);
        isAdLoaded = false;
        RequestRewardedAd();
    }

   
    void Update()
    {
        
        //Debug.Log(adState);
        if (rewardedAd.IsLoaded())
        {
            isAdLoaded = true;
        }
        if(adState == 1)
        {
            kingScript.Reborn();
        }

        if(adState == -1)
        {
            gameOverScript.FinishTheGame();
        }
        
    }



    public void RequestRewardedAd()
    {
        AdRequest request = AdRequestBuild();
        rewardedAd.LoadAd(request, rewardedID);

        rewardedAd.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded += this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed += this.HandleOnRewardedAdClosed;
    }

    public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("loaded");
        adState = 3;
    }
    public void HandleOnAdRewarded(object sender, EventArgs args)
    {
        adState = 1;
        
    }
    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {
        rewardedAd.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        rewardedAd.OnAdRewarded -= this.HandleOnAdRewarded;
        rewardedAd.OnAdClosed -= this.HandleOnRewardedAdClosed;
        if(adState != 1)
        {
            playerAdCount = PlayerPrefs.GetInt("PlayerDontWatchTheAds");
            playerAdCount++;
            PlayerPrefs.SetInt("PlayerDontWatchTheAds", playerAdCount);
            adState = -1;
        }
    }
    public void ShowRewardAd()
    {

        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }
}
