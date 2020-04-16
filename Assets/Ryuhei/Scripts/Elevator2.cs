using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour {

    public float speed = 1.0f;
    private Vector3 defaultPosition;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        defaultPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Static;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.position = defaultPosition + new Vector3(0, speed, 0);
        Debug.Log("当たっている");
    }
}