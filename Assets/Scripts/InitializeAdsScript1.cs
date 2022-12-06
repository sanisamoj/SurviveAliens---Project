using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdsScript1 : MonoBehaviour
{
    public string gameId = "3781923";
    public string placementId = "banner";
    public bool testMode = true;

    public static bool destroyAds = false;

    void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Initialize(gameId, testMode);
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        
        if (Config.qntPlayerDie != 2)
        {
            Advertisement.Banner.Show(placementId);
        }
    }

    private void Update()
    {
        if (PlayerConfig.vida <= 0.01f)
        {
            StartCoroutine(ShowBannerWhenInitialized());
        } else
        {
            Advertisement.Banner.Hide(false);
        }  
    }
}
