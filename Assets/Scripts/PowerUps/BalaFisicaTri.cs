using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaFisicaTri : MonoBehaviour
{
    public float tempoDissipagem = 2.0f;
    public static float danoBala = 20;

    // Start is called before the first frame update
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
            PlayerConfig.pontos += 22;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
