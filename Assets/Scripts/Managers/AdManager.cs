
using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    private BannerView _bannerView;
    private InterstitialAd _interstitialAd;

    private void OnEnable()
    {
        EventManager.Instance.gameEvents.OnGameOver += ShowInterstitialAd;
    }
    private void OnDisable()
    {
        EventManager.Instance.gameEvents.OnGameOver -= ShowInterstitialAd;
    }

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initstatus) =>
        {
            if (initstatus == null)
            {
                return;
            }
            
        });
        
        MobileAds.SetRequestConfiguration(
            new RequestConfiguration()
            {
                MaxAdContentRating = MaxAdContentRating.G,
                TagForChildDirectedTreatment = TagForChildDirectedTreatment.True
            });
        
        CreateBannerAd();
        CreateInterstitialAd();
    }

    private void CreateBannerAd()
    {
        _bannerView = new BannerView("ca-app-pub-4024174422625286/1960950557", AdSize.Banner, AdPosition.Bottom);
        _bannerView.LoadAd(new AdRequest());
    }

    private void CreateInterstitialAd()
    {
        var adRequest = new AdRequest();

        InterstitialAd.Load("ca-app-pub-4024174422625286/7255533470", adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                return;
            }
            _interstitialAd = ad;
        });
    }

    private void ShowInterstitialAd()
    {
        var randomChance = Random.Range(0,5);
        if (_interstitialAd != null && _interstitialAd.CanShowAd() && randomChance < 3)
        {
            _interstitialAd.Show();
        }
    }
}
