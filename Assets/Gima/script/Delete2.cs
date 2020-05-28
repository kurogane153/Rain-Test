using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete2 : MonoBehaviour {

    GameObject obj;

    void Start()
    {
        obj = GameObject.Find("Rain");
    }

    //当たった時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rain_Red")
        {
            Destroy(collision.gameObject);
        }
    }
}
