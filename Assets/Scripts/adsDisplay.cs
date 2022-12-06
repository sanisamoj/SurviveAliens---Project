using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsDisplay : MonoBehaviour
{
    string gameId = "3781923";
    public string placementId = "GameOver";
    bool testMode = true;

    void Start()
    {
        Config.playerAlive = true;
        Advertisement.Initialize(gameId, testMode);
        
        if(Config.qntPlayerDie >= 3)
        {
            Advertisement.Show(placementId);
            Config.qntPlayerDie = 0;
        }        
    }

    private void LateUpdate()
    {
        Destroy(gameObject);
    }

}

