using UnityEngine;
using System;

public class AdmobController : MonoBehaviour
{

    public static AdmobController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!CUtils.IsBuyItem() && !CUtils.IsAdsRemoved())
        {
            RequestBanner();
            Timer.Schedule(this, 5f, RequestBanner);
            RequestInterstitial();
        }

        InitRewardedVideo();
        RequestRewardBasedVideo();
    }

    private void InitRewardedVideo()
    {
        
    }

    public void RequestBanner()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = GameConfig.instance.admob.androidBanner.Trim();
#elif UNITY_IPHONE
        string adUnitId = GameConfig.instance.admob.iosBanner.Trim();
#else
        string adUnitId = "unexpected_platform";
#endif

       
    }

    public void RequestInterstitial()
    {
       
    }

    public void RequestRewardBasedVideo()
    {
    }

    // Returns an ad request with custom ad targeting.
 
    public bool ShowInterstitial()
    {
     
        return false;
    }

    public void ShowRewardBasedVideo()
    {
      
        
        {
            MonoBehaviour.print("Reward based video ad is not ready yet");
        }
    }
    
}
