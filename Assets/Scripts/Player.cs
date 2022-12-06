using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public FixedJoystick variableJoystick;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject prefab;
    public GameObject multiTiro;
    public float speedTiro = 2.0f;

    public static bool tiroNormal = true;

    private void Update()
    {
        gameObject.transform.rotation = Quaternion.identity;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Atirar();
        }
    }

    public void FixedUpdate()
    {
        Vector3 direction = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical);

        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        else if (direction.x > 0)
        {
            sr.flipX = false;
        }
        rb.velocity = direction * speed; ;
    }

    public void Atirar()
    {
        if(tiroNormal)
        {
            var posicaoPlayer = GameObject.FindGameObjectWithTag("Player");
            Vector3 positionPlayer = posicaoPlayer.transform.position;
            var clone = Instantiate(prefab, positionPlayer, prefab.transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = sr.flipX == true ? Vector2.left * speedTiro : Vector2.right * speedTiro;
            PlayerConfig.tirosDados++;
        } 
        else
        {
            var posicaoPlayer = GameObject.FindGameObjectWithTag("Player");
            Vector3 positionPlayer = posicaoPlayer.transform.position;
            var clone = Instantiate(multiTiro, positionPlayer, prefab.transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = sr.flipX == true ? Vector2.left * speedTiro : Vector2.right * speedTiro;
            PlayerConfig.tirosDados++;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rocha"))
        {
            PlayerConfig.vida -= 32;
        } else if (collision.gameObject.CompareTag("enemy"))
        {
            PlayerConfig.vida -= Enemy.danoEnemy;
            PlayerConfig.pontos = +2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tiroEnemy"))
        {
            PlayerConfig.vida -= BalaEnemy.danoBala;
            
        }
    }

}
