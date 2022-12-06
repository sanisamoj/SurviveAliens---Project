using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    public float tempoDissipagem = 4.0f;
    public static float danoBala = 20;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempoDissipagem);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
