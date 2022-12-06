using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRocha : MonoBehaviour
{
    private Vector3[] posicoesRpwRocha = {new Vector3(26.21f, 0.49f, 0.0f), new Vector3(19.68f, -8.1f, 0.0f), new Vector3(9.42f, 8.74f, 0.0f),
    new Vector3(2.06f, 9.98f, 0.0f), new Vector3(13.53f, -2.12f, 0.0f), new Vector3(-1.85f, 6.54f, 0.0f)};

    public static int quantidadeRocha;
    public GameObject prefabRochas;

    void Start()
    {
        quantidadeRocha = RespawnRochas();

        for (var i = 0; i <= quantidadeRocha; i++)
        {
            var n = RespawnRochasPositions();

            Instantiate(prefabRochas, posicoesRpwRocha[n], prefabRochas.transform.rotation);
            Config.quantidadeRochaGerado++;
        }

        Destroy(gameObject, 1.0f);

    }

    int RespawnRochas()
    {
        if (Config.distancia > 5000)
        {
            return Random.Range(4, 7);
        }
        else if (Config.distancia >= 1500 && Config.distancia < 5000)
        {
            return Random.Range(2, 4);
        } 
        else
        {
            return Random.Range(1, 3);
        }

    }

    int RespawnRochasPositions()
    {
        return Random.Range(0, posicoesRpwRocha.Length);
    }
}
