﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedVideoButton : MonoBehaviour
{
    private const string ACTION_NAME = "rewarded_video";

    private void OnEnable()
    {
        Timer.Schedule(this, 0.1f, AddEvents);
    }

    private void AddEvents()
    {
#if UNITY_ANDROID || UNITY_IOS
        
#endif
    }

    public void OnClick()
    {
        if (IsAvailableToShow())
        {
            AdmobController.instance.ShowRewardBasedVideo();
        }
        else if (!IsActionAvailable())
        {
            int remainTime = (int)(GameConfig.instance.rewardedVideoPeriod - CUtils.GetActionDeltaTime(ACTION_NAME));
            Toast.instance.ShowMessage("Please wait " + remainTime + " seconds for the next ad");
        }
        else
        {
            Toast.instance.ShowMessage("Ad is not available now, please wait..");
        }

        Sound.instance.PlayButton();
    }

    public bool IsAvailableToShow()
    {
        return IsActionAvailable() && IsAdAvailable();
    }

    private bool IsActionAvailable()
    {
        return CUtils.IsActionAvailable(ACTION_NAME, GameConfig.instance.rewardedVideoPeriod);
    }

    private bool IsAdAvailable()
    { return false;
    }

    private void OnDisable()
    {
#if UNITY_ANDROID || UNITY_IOS
#endif
    }
}
