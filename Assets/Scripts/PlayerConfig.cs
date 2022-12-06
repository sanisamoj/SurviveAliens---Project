using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConfig : MonoBehaviour
{
    private Vector3 vectorVida;
    public GameObject playervida;
    [SerializeField]
    public Transform transformVida;
    public static bool vivoPFirst;
    
    public static float pontos;
    public static float vida;
    public Texture Sangue, Contorno;
    public float VidaCheia = 300;
    public static int tirosDados;

    public float x = 71;
    public float y = 36;
    public float largura = 110;
    public float altura = 15;

    public float xcontorno = 50;
    public float ycontorno = 20;
    public float larguraContorno = 152;
    public float alturaContorno = 51;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playervida = GameObject.FindGameObjectWithTag("vida");
    }

    void Update()
    {
        if (vida >= VidaCheia)
        {
            vida = VidaCheia;

        }
        else if (vida <= 0)
        {
            Config.pontosIniciais = false;
            vida = 0;
            Config.playerAlive = false;
            player.SetActive(false);
            Config.qntPlayerDie += 1;
        }

        if (vivoPFirst == true)
        {
            pontos = 0;
            vida = 500;
            player.transform.position = new Vector3(-6.4f, 1.4f, 0.0f);
            player.SetActive(true);
            Config.playerAlive = true;
            Config.pontosIniciais = true;
            vivoPFirst = false;        
        }

        vectorVida = new Vector3(0.999449f / VidaCheia * vida, 1.176178f);
        playervida.transform.localScale = vectorVida;
    }

}
