using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class PlayAdvertisement : Singleton<PlayAdvertisement>
{
    private InterstitialAd interstitial;

    void Start()
    {
        Advertisement();
    }

    public void Advertisement()
    {
        //주석처리된건 진짜 광고 이걸로 테스트 하면 계정 정지됨
        //string adUnitId = "ca-app-pub-5708876822263347/8203733587";
        string adUnitId = "ca-app-pub-3940256099942544~3347511713";
        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    /// <summary>
    /// 주의! 광고 실행중일땐 게임이 정지된다.
    /// </summary>
    public void PlayingAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        Advertisement();
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //광고 닫으면 일어나는 일
    }
}
