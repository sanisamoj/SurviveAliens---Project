using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGold : MonoBehaviour
{
    private Vector3[] posiçoesToGo = { new Vector3(-9.61f, 3.77f), new Vector3(-0.29f, 0.66f), new Vector3(7.55f, 2.18f),
    new Vector3(5.06f, -3.2f), new Vector3(-1.81f, 1.94f), new Vector3(-3.47f, -2.34f), new Vector3(2.09f, -2.34f), 
    new Vector3(2.96f, 1.05f) };

    public int pontos;
    private Vector3 local;
    public float forca;
    public Rigidbody2D rb2;

    void Start()
    {
        forca = RandomSpeed();
        pontos = RandomPontos();
        rb2 = GetComponent<Rigidbody2D>();
        local = (posiçoesToGo[RandomPosition()] - gameObject.transform.position).normalized;
        rb2.velocity = local * forca;

        Destroy(gameObject, 3f);
    }

    public int RandomPontos()
    {
        return Random.Range(100, 400);
    }

    public int RandomPosition()
    {
        return Random.Range(0, posiçoesToGo.Length);
    }

    public float RandomSpeed()
    {
        return Random.Range(6.02f, 12f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("tiro"))
        {
            PlayerConfig.pontos += pontos;
            Destroy(gameObject);
        }
    }


}
