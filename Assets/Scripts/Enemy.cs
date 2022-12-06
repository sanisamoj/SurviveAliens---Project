using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool allDestroy = false;

    public float eixoX = 0;
    public float eixoY = 0;
    public float eixoZ = 0;

    public float speed = 2;
    public float velTiro = 7;
    public static float danoEnemy = 25;

    public bool rotacaoLigado = true;

    private float vida = 35;
    private GameObject player;
    private Vector3 posicao;

    public Rigidbody2D rb2;
    public GameObject prefab;

    [SerializeField]
    private Animator explosion;

    public static Vector3 enemyPosition;
    private Vector3 moviment;
    public float acelerationTime = 6.0f;
    private float timeLeft = 6.0f;

    private float speedRotation ;

    public static float tempoInvokingAtira = 2.9f;

    private void Awake()
    {
        vidaRocha.allDestroy = false;
        Enemy.allDestroy = false;
    }

    void Start()
    {
        explosion = gameObject.GetComponent<Animator>();
        tempoInvokingAtira = RandomSpeedEnemy();
        speed = RandomSpeedEnemy();

        InvokeRepeating("Atira", 0.5f, tempoInvokingAtira);

        player = GameObject.FindGameObjectWithTag("Player");

        enemyPosition = gameObject.transform.position;

        speedRotation = RandomSpeedRotation();
    }

    void Update()
    {
       
        if (vida <= 0 || allDestroy == true)
        {
            Config.quantidadeEnemyGerado -= 1;
            explosion.SetBool("dead", true);
            Destroy(gameObject, 0.7f);
            
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft > 3 && Config.playerAlive == true)
        {
            if (timeLeft < 6)
            {
                moviment = (player.transform.position - gameObject.transform.position).normalized;
            }
        }

        if (timeLeft <= 3)
        {
            moviment = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft = 9;
        }

        if (rotacaoLigado)
        {
            gameObject.transform.Rotate(eixoX, eixoY, eixoZ * speedRotation);
        }
    }

    void FixedUpdate()
    {
        rb2.velocity = moviment * speed;
    }

    public void Atira()
    {
        posicao = (player.transform.position - gameObject.transform.position).normalized;

        var clone = Instantiate(prefab, gameObject.transform.position, prefab.transform.rotation);

        clone.GetComponent<Rigidbody2D>().velocity = posicao * velTiro;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tiro"))
        {
            vida -= BalaFisica.danoBala;
        }
    }

    public float RandomSpeedEnemy ()
    {
        return Random.Range(1.5f, 3.5f);
    }

    public float AtiraSpeed()
    {
        return Random.Range(2.5f, 4.0f);
    }

    private float RandomSpeedRotation()
    {
        return Random.Range(3.5f, 6.5f);
    }

    private void OnDisable()
    {
        if (Config.playerAlive == true)
        {
            PlayerConfig.pontos += 45;
        } else
        {
            PlayerConfig.pontos = 0;
        }
        
    }
}
