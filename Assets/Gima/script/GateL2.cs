using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateL2 : MonoBehaviour {

    private float Rot = 0.0f;
    private GameObject Player;
    private bool EDInisSwitch = false;

    void Start () {
        Player = GameObject.Find("Player");
    }

	void Update () {
        if (160.0f <= Player.transform.position.x)
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
