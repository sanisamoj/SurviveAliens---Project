using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaFisica : MonoBehaviour
{
    public float tempoDissipagem = 2.0f;
    public static float danoBala = 20;

    public Vector3 direction;

    void Start()
    {
        Destroy(gameObject, tempoDissipagem);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rocha"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("tiroEnemy"))
        {
            PlayerConfig.pontos += 25;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
