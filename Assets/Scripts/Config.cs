using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour
{
    [SerializeField]
    private GameObject ads;
    public static bool adsRespawn = false;

    public float positionX, positionY;
    public float eixoX;
    public float eixoY;

    public GameObject allDestroy;
    public GameObject coin;
    public Text textRecord;
    public int qntGerado;
    private int qntTiros = PlayerConfig.tirosDados;
    private GameObject player;

    public static int qntPlayerDie = 2;

    public static float distancia;
    public static float ditanciaXtempo = 10;
    public static float speedBack = 0.7f;

    public static bool playerAlive = true;
    public static bool pontosIniciais = false;
    public static bool pontosFinaiss = false;

    public static int quantidadeEnemyGerado;
    public static int quantidadeRochaGerado;

    public static int qntEneDinamic = 4;
    public static float tempoEnemy;
    public static float tempoRocha;
    public float tempoPickups = 1f;
    public float tempoPickupsCoin = 1f;
    public float tempoEnemyRespawn = 15.0f;
    public float tempoRochaRespawn = 19.0f;
    public float tempoPickupsRespawn = 30.0f;

    public GameObject menu;

    public Text text;
    public Text HS;
    public Text dit;

    private float pontosFinais;
    public static float pontosDistanciaFinais;

    public GameObject objectEnemy;
    public GameObject objectRocha;
    public GameObject objectPickups;

    private GameObject[] qntEnemToDestroy;
    private GameObject[] qntRochaToDestroy;

    void Start()
    {
        tempoEnemy = 100000.5f;
        tempoRocha = 100000.5f;

        distancia = 0;
        PlayerConfig.vida = 300;

        menu.SetActive(false);
    }

    void Update()
    {
        tempoPickupsCoin -= Time.deltaTime;
        distancia += ditanciaXtempo * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (distancia > 1000 && distancia < 2000)
        {
            ditanciaXtempo = 20;
            speedBack = 0.9f;

        } else if (distancia > 2000 && distancia < 4000)
        {
            ditanciaXtempo = 35;
            speedBack = 1.2f;
            qntEneDinamic = 6;

        } else if (distancia > 3000)
        {
            qntEneDinamic = 8;
            ditanciaXtempo = 50;
            speedBack = 1.9f;
        } else
        {
            qntEneDinamic = 4;
            ditanciaXtempo = 10;
            speedBack = 0.8f;
        }

        if(tempoEnemy <= 0)
        {
            var clone = Instantiate(objectEnemy, Vector3.zero, Quaternion.identity);
            tempoEnemy = RetornatempoRandom();
        }

        if(tempoRocha <= 0)
        {
            var cloneRochas = Instantiate(objectRocha, Vector3.zero, Quaternion.identity);
            tempoRocha = RetornaTempoRandomRocha();
        }

        if (tempoPickups <= 0)
        {
            Instantiate(objectPickups, Vector3.zero, objectPickups.transform.rotation);
            tempoPickups = RetornaTempoRandomPickup();
        }

        if (tempoPickupsCoin <= 0)
        {
            Instantiate(coin, Vector3.zero, objectPickups.transform.rotation);
            tempoPickupsCoin = RetornaTempoRandomPickupCoin();
        }

        if (pontosIniciais == true)
        {
            text.text = PlayerConfig.pontos.ToString() + " | " + distancia.ToString("0") + "m";
            pontosFinais = PlayerConfig.pontos;
            pontosDistanciaFinais = distancia;

            tempoEnemy -= Time.deltaTime;
            tempoRocha -= Time.deltaTime;
            tempoPickups -= Time.deltaTime;
            
        }   

        if (playerAlive == false)
        {
            menu.SetActive(true);
            
            playerAlive = true;
            
        }

        HS.text = "HighScore: " + pontosFinais.ToString();
        dit.text = "Distance: " + pontosDistanciaFinais.ToString("0");

        textRecord.text = "Personal Record: " + PlayerPrefs.GetFloat("distance").ToString("0");

        if (PlayerConfig.vida == 0)
        {
            Instantiate(ads);
            PlayerConfig.vida = 0.01f;
        }

    }

    public float RetornatempoRandom()
    {
        return Random.Range(9.0f, 15.0f);
    }

    public float RetornaTempoRandomRocha()
    {
        return Random.Range(12.0f, 19.0f);
    }

    public float RetornaTempoRandomPickup()
    {
        return Random.Range(30.0f, 50f);
    }

    public float RetornaTempoRandomPickupCoin()
    {
        return Random.Range(25.0f, 45f);
    }

    public void btnPlayAgain ()
    {
        Instantiate(allDestroy, Vector3.zero, allDestroy.transform.rotation);     
        PlayerConfig.vivoPFirst = true;
        qntGerado++;
        menu.SetActive(false);
        InitializeAdsScript1.destroyAds = true;
        distancia = 0;
        PlayerConfig.pontos = 0;
    }

    public void btnExit()
    {
        Application.Quit();
    }
    
    public void DestroyAll()
    {
        if (PlayerConfig.pontos >= 2000)
        {
            PlayerConfig.pontos -= 2000;
            vidaRocha.allDestroy = true;
            Enemy.allDestroy = true;
        }     
    }

    public void VidaButton()
    {
        if (PlayerConfig.pontos >= 500 && PlayerConfig.vida < 300)
        {
            PlayerConfig.pontos -= 500;
            PlayerConfig.vida += 100;
        }
    }

}
