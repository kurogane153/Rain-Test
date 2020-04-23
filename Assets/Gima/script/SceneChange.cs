using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour {

    public bool fed = false;

    void Start () {

    }

	void Update () {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fed = true;
        }
    }
}
