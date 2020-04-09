using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor_Cloud_Scripts : MonoBehaviour {

    public float FallSpeed = -1.0f;
    private Rigidbody2D rigid;
    private Vector3 defaultPos;
    private bool FallSwitch = false;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Static;
        defaultPos = transform.position;
	}

    private void FixedUpdate()
    {
        if (FallSwitch == true)
        {
            rigid.bodyType = RigidbodyType2D.Dynamic;

            transform.position = defaultPos + new Vector3(0, FallSpeed * Time.deltaTime, 0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FallSwitch = true;
        }
    }
}
