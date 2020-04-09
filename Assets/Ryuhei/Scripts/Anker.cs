using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anker : MonoBehaviour {

    private Rigidbody2D rb; // this Rigidbody2D

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }
	
	// Update is called once per frame
	void Update () {

        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標基準で、現在の回転量へ加算する
        myTransform.Rotate(0.0f, 0.0f, Mathf.Sin(Time.time) + 0.50f);

    }
}
