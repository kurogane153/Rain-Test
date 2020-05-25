using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    GameObject efect;
    public bool fix = false;

	// Use this for initialization
	void Start () {
        efect = GameObject.Find("HighVoltageLine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        fix = true;
        Destroy(efect);
    }
}
