using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgoundEasy : MonoBehaviour
{
    public MeshRenderer bg;

    public Camera cameraa;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bg.material.mainTextureOffset += new Vector2(Config.speedBack * Time.deltaTime, 0f);
    }
}
