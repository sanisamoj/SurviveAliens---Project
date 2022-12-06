using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCoin : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCoin;

    private Vector3[] posiçoesRespawn = { new Vector3(12.43f, 6.44f), new Vector3(12.54f, 0.33f), new Vector3(12.43f, -6.54f), new Vector3(-0.76f, 8.96f),
    new Vector3(-7.59f, 8.96f), new Vector3(-13.44f, 7.92f), new Vector3(-13.91f, 0.87f), new Vector3(-13.69f, -6.75f), new Vector3(-0.18f, -8.77f)};

    private int qntGerado;

    void Start()
    {
        qntGerado = qntCoin();

        for (var i = 0; i < qntGerado; i++ )
        {
            var p = RespawnCoinPositions();
            Instantiate(prefabCoin, posiçoesRespawn[p], prefabCoin.transform.rotation);
        }

        Destroy(gameObject, 1.0f);
    }

    int qntCoin()
    {
        return Random.Range(1, 4);
    }

    int RespawnCoinPositions()
    {
        return Random.Range(0, posiçoesRespawn.Length);
    }
}
