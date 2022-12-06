using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    private Vector3[] posicoesRespawn = {new Vector3(-2.82f, -7.56f, 0.0f), new Vector3(1.49f, -7.53f, 0.0f), new Vector3(4.97f, -7.54f, 0.0f),
    new Vector3(7.94f, -7.54f, 0.0f), new Vector3(11.29f, -6.57f, 0.0f), new Vector3(11.25f, -3.86f, 0.0f), new Vector3(12.01f, -0.98f, 0.0f), new Vector3(11.93f, 2.24f, 0.0f),
    new Vector3(11.59f, 5.8f, 0.0f), new Vector3(11.59f, 5.8f, 0.0f), new Vector3(8.33f, 7.67f, 0.0f), new Vector3(5.19f, 7.67f, 0.0f), new Vector3(1.71f, 7.67f, 0.0f),
    new Vector3(-1.51f, 7.67f, 0.0f)};

    public static int quantidadeEnemy;

    public GameObject prefabEnemy;

    void Start()
    {
        quantidadeEnemy = RespawnEnemies();

        for (var i = 0; i <= quantidadeEnemy; i++)
        {
            var n = RespawnEnmiesPositions();

            Instantiate(prefabEnemy, posicoesRespawn[n], prefabEnemy.transform.rotation);

            Config.quantidadeEnemyGerado++;
        }

        Destroy(gameObject, 1.0f);
    }

    int RespawnEnemies()
    {
        return Random.Range(2, Config.qntEneDinamic);
    }

    int RespawnEnmiesPositions()
    {
        return Random.Range(0, posicoesRespawn.Length);
    }

    
}
