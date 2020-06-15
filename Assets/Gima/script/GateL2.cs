using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateL2 : MonoBehaviour {

    private float Rot = 0.0f;
    public AudioClip sound1;
    private GameObject Player;
    AudioSource audioSource;
    private bool EDInisSwitch = false;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("Player");
    }

	void Update () {

        if (167.50f <= Player.transform.position.x)
        {
            EDInisSwitch = true;
        }

        if (EDInisSwitch == true)
        {
            if (Rot <= 1.0f)
            {
                Rot += 0.01f;
                this.gameObject.transform.Rotate(0, 0, Rot);
                audioSource.PlayOneShot(sound1);
            }
            if (Rot > 0.50f)
            {
                //EDInisSwitch = false;
            }
        }
    }
}
