using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LifeRoxo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2;
    private float speedF;
    private GameObject player;
    private Vector3 local;

    private Vector3[] locaisParaIr = { new Vector3(2.93f, 0.17f, 0.0f), new Vector3(-4.31f, -1.06f), new Vector3(-0.69f, 0.16f, 0.0f), 
    new Vector3(-7.48f, 0.16f, 0.0f)};
    private Vector3 localIr;

    void Start()
    {
        localIr = locaisParaIr[RandomPosition()];
        player = GameObject.FindGameObjectWithTag("Player");
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        speedF = RandomSpeedItem();
        local = (localIr - gameObject.transform.position).normalized;
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0.0f, 0.0f, 1.0f * speed);
    }

    private void FixedUpdate()
    {
        rb2.velocity = local * speedF;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerConfig.vida += 35;
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("tiro"))
        {
            PlayerConfig.pontos += 15;
            PlayerConfig.vida += 35;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }


    public int RandomPosition()
    {
        return Random.Range(0, locaisParaIr.Length);
    }
    public float RandomSpeedItem()
    {
        return Random.Range(7, 12);
    }


}
