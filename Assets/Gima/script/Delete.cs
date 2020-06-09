using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

    public bool fix = false;

    //GameObject obj;

    //void Start()
    //{
    //   obj = GameObject.Find("Rain");
    //}

    //当たった時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rain" || collision.gameObject.tag == "Rain_Green"
            || collision.gameObject.tag == "Rain_White")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Rain_Red")
        {
            fix = true;
        }
    }
}
