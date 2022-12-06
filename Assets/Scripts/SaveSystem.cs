using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private float distance;

    // Update is called once per frame
    void Update()
    {
        if (Config.pontosDistanciaFinais > PlayerPrefs.GetFloat("distance"))
        {
            distance = Config.pontosDistanciaFinais;
            PlayerPrefs.SetFloat("distance", distance);
        }
    }
}
