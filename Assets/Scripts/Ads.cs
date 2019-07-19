using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour
{
	public string mobileAppId = "ca-app-pub-3345588211008595~1929521622", 
		unitBannerId="ca-app-pub-3345588211008595/2702234161", 
		unitInterstisialId = "ca-app-pub-3345588211008595/3677717563";
	private BannerView banner;
	//private IntersitialAd inter;

    // Start is called before the first frame update
    void Start()
    {
		MobileAds.Initialize (mobileAppId);
		banner = new BannerView (unitBannerId, AdSize.Banner, AdPosition.Top);
		AdRequest req = new AdRequest.Builder ().Build ();
		banner.LoadAd (req);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
