using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio2 : MonoBehaviour {

    public AudioClip sound1;
    AudioSource audioSource;

    void Start () {

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {

        if (Input.GetButtonDown("X")||Input.GetButtonDown("O"))
        {
            audioSource.PlayOneShot(sound1);
        }

    }
}
