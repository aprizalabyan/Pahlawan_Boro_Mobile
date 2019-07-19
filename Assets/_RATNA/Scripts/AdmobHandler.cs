using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class AdmobHandler : MonoBehaviour {
    public static AdmobHandler Instance = null;
    public string AppId = null;
    public string AdUnitId = null;
    public string TestDevice = null;
    private InterstitialAd interstitial;
	// Use this for initialization
    private bool isIntersReady = false;
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    
    }
	void Start () {
        MobileAds.SetiOSAppPauseOnBackground(true);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(AppId);
        this.RequestInterstitial();
        StartCoroutine("reInters");
	}


    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice(TestDevice)
            .Build();
    }

    private void RequestInterstitial()
    {


        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(AdUnitId);

        // Register for ad events.
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    private void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
    }

    #region FUNGSI UNTUK MENJADA INTERSTITIAL TETAP READY
    IEnumerator reInters() {
        while (true) {
            yield return new WaitForSeconds(10.0f);
            if (isIntersReady == false) {
                this.RequestInterstitial();
            }
        }
        
    }
    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLoaded event received");
        isIntersReady = true;
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleInterstitialFailedToLoad event received with message: " + args.Message);
        isIntersReady = false;
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialClosed event received");
        isIntersReady = false;
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    #endregion


    #region FUNGSI YANG BISA DI AKSES DARI LUAR UNTUK MENAMPILKAN INTERSTITIAL
    //**
    //
    //  CARA MENGGUNAKANYA ATAU MEMANGGILKAN DARI LUAR KODE / KELAS INI AdmobHandler.Instance.ShowIntersAd();
    //
    public void ShowIntersAd() {
        this.ShowInterstitial();
    }
    #endregion
}
