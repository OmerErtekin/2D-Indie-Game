using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;


public class InterstitialAdScript : MonoBehaviour
{
    private string interID;
    private string appID;
    private InterstitialAd interAd;

    void Start()
    {

        appID = "ca-app-pub-3934768444739338~3058468135";
        interID = "ca-app-pub-3934768444739338/4671782764";
        // TEST ID: ca-app-pub-3940256099942544/1033173712
        MobileAds.Initialize(appID);
        this.RequestInterstitialAd();
    }




     public void RequestInterstitialAd()
    {
        this.interAd = new InterstitialAd(interID);

        this.interAd.OnAdClosed += HandleOnClosed;
        AdRequest request = new AdRequest.Builder().Build();

        this.interAd.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if(interAd.IsLoaded() == true)
        {
            interAd.Show();
        }
        PlayerPrefs.SetInt("PlayerDontWatchTheAds", 0);
    }

    public void HandleOnClosed(object sender, EventArgs args)
    {
        RequestInterstitialAd();       
    }





}
