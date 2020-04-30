using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_X : MonoBehaviour {

    public float x = 0.5f;

	void Start () {
		
	}

	void Update () {
        this.transform.position = new Vector3(x, 0, 0);
	}
}
