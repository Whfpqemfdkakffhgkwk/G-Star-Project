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
        //�ּ�ó���Ȱ� ��¥ ���� �̰ɷ� �׽�Ʈ �ϸ� ���� ������
        //string adUnitId = "ca-app-pub-5708876822263347/8203733587";
        string adUnitId = "ca-app-pub-3940256099942544~3347511713";
        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    /// <summary>
    /// ����! ���� �������϶� ������ �����ȴ�.
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
        //���� ������ �Ͼ�� ��
    }
}
