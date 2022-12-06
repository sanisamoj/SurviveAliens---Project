using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class vidaRocha : MonoBehaviour
{
    public static bool allDestroy = false;

    public float hpRocha = 60;
    public float pontosRochaDestruida = 100.5f;
    public float speed = 6f;

    private GameObject player;
    private Vector3 local;

    [SerializeField]
    private Animator explosionEffect;

    public Rigidbody2D rb2;
    public float forca = 1;

    [SerializeField]
    private SpriteRenderer sprt;

    private void Awake()
    {
        vidaRocha.allDestroy = false;
        Enemy.allDestroy = false;
    }

    void Start()
    {      
        forca = RandomSpeedRocha();
        rb2 = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        local = (player.transform.position - gameObject.transform.position).normalized;
        Destroy(gameObject, 10.0f);
    }

    void Update()
    {
        if (hpRocha <= 0 || allDestroy == true)
        {
            sprt.enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            explosionEffect.SetBool("dead", true);
            Destroy(gameObject, 0.7f);
        }

        gameObject.transform.Rotate(0.0f, 0.0f, 1.0f * speed);
    }

    void FixedUpdate()
    {
        rb2.velocity = local * forca;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("colider"))
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("colider"))
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rocha") || collision.gameObject.CompareTag("colider"))
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tiro"))
        {
            hpRocha -= BalaFisica.danoBala;
        } else if (collision.gameObject.CompareTag("tiroEnemy"))
        {
            hpRocha -= BalaEnemy.danoBala;
        }
    }

    public float RandomSpeedRocha()
    {
        return Random.Range(8, 16);
    }

    private void OnDisable()
    {
        
        if(Config.playerAlive == true)
        {
            PlayerConfig.pontos += pontosRochaDestruida;
        }
        else
        {
            PlayerConfig.pontos = 0;
        }
    }
}
