using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

    bool isMoving = false;
    public float speed = 0.010f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isMoving == true)
        {
            this.transform.position += new Vector3(0.0f, speed, 0.0f);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isMoving = true;
        }
    }
}
