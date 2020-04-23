using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenechange２ : MonoBehaviour {

    public bool fed2 = false;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fed2 = true;
        }
    }
}
