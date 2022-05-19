using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdSettings : MonoBehaviour, IInterstitialAdListener
{
    private const string AppKey = "7c29382152c69abc0838bdd6699cc9cb494ebded4ecc39d8";

    private void Start()
    {
        int adTypes = Appodeal.INTERSTITIAL;
        Appodeal.initialize(AppKey, adTypes, true);
        Appodeal.setInterstitialCallbacks(this);
    }

    public void ShowInterstival()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL) && !Appodeal.isPrecache(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
        else
            return;
    }

    public void onInterstitialClicked()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialLoaded(bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShown()
    {
        throw new System.NotImplementedException();
    }
}
