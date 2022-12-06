using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private GameObject canvas;

    private void Start()
    {       
        canvas = GameObject.FindGameObjectWithTag("canvas");
    }


    public void Exitgame()
    {
        Application.Quit();
    }

    public void GameStart ()
    {
        Config.tempoEnemy = 3.0f;
        Config.tempoRocha = 7.5f;
        Config.distancia = 0;
        Config.pontosIniciais = true;
        Destroy(canvas);
    }
}
