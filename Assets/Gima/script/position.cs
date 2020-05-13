using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour {

    private GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Player.transform.position;
	}
}
