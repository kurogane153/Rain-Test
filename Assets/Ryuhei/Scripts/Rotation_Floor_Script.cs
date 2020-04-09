using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Floor_Script : MonoBehaviour {

    public float RotationX = 0.0f;
    public float RotationY = 0.0f;
    public float RotationZ = -1.0f;
    private Rigidbody2D rb; // this Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update () {
        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標基準で、現在の回転量へ加算する
        myTransform.Rotate(RotationX, RotationY, RotationZ);
    }
}
