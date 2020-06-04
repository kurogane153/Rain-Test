using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateL : MonoBehaviour {

    private float Rot = 0.0f;
    private GameObject Player;
    private bool EDInisSwitch = false;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
    

    // Update is called once per frame
    void Update () {

        if (297.0f <= Player.transform.position.x)
        {
            EDInisSwitch = true;
        }
        
        if (EDInisSwitch == true)
        {
            if (Rot <= 1.0f)
            {
                Rot += 0.01f;
                this.gameObject.transform.Rotate(0, 0, Rot);

                Debug.Log(Rot);
            }

            if (Rot > 0.50f)
            {
                EDInisSwitch = false;
            }
        }
	}
}
