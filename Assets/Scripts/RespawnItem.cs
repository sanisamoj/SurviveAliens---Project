using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{
    private Vector3[] posicoesRpwItem = {new Vector3(26.21f, 0.49f, 0.0f), new Vector3(19.68f, -8.1f, 0.0f), new Vector3(9.42f, 8.74f, 0.0f),
    new Vector3(2.06f, 9.98f, 0.0f), new Vector3(13.53f, -2.12f, 0.0f), new Vector3(-1.85f, 6.54f, 0.0f)};

    public static int quantidadeItem;
    public GameObject prefabItem;

    void Start()
    {
        quantidadeItem = RespawnItens();

        for (var i = 0; i <= quantidadeItem; i++)
        {
            var n = RespawnRochasPositions();

            Instantiate(prefabItem, posicoesRpwItem[n], prefabItem.transform.rotation);
            Config.quantidadeRochaGerado++;
        }

        
    }

    private void LateUpdate()
    {
        Destroy(gameObject, 1.0f);
    }
    int RespawnItens()
    {
        if (Config.distancia > 1000)
        {
            return Random.Range(1, 2);
        }
        else
        {
            return Random.Range(1, 2);
        }

    }

    int RespawnRochasPositions()
    {
        return Random.Range(0, posicoesRpwItem.Length);
    }
}
