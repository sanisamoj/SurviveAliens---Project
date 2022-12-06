using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDestroy : MonoBehaviour
{
    private GameObject[] allObjects;
    private GameObject[] allRochas;
    private GameObject[] allShooter;

    void Start()
    {
        allObjects = GameObject.FindGameObjectsWithTag("enemy");
        allRochas = GameObject.FindGameObjectsWithTag("rocha");
        allShooter = GameObject.FindGameObjectsWithTag("tiroEnemy");

        for (var i = 0; i < allObjects.Length; i++)
        {
            Destroy(allObjects[i]);
        }

        for (var i = 0; i < allRochas.Length; i++)
        {
            Destroy(allRochas[i]);
        }

        for (var i = 0; i < allShooter.Length; i++)
        {
            Destroy(allShooter[i]);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerConfig.pontos = 0;
        Destroy(gameObject);
    }
}
