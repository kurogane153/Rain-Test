using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio2 : MonoBehaviour {

    public AudioClip sound1;
    AudioSource audioSource;
    private GameObject Player;

    void Start () {

        Player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetButtonDown("B"))
        {
            if (CameraSwitching2.ThisEventOnTrigger == false && GateR2.EDInisSwitch == false
            && GateR.EDInisSwitch == false)
            {
                if (Player.gameObject.GetComponent<TestJump_ver2>().isGrounded)
                {
                    audioSource.PlayOneShot(sound1);
                }
            }
        }
    }
}
