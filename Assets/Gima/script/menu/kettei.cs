using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kettei : MonoBehaviour {

    public AudioClip sound1;
    AudioSource audioSource;
    bool flg = false;

    void Start () {

        audioSource = GetComponent<AudioSource>();

    }

	void Update () {
        if (Input.GetButtonDown("B"))
        {
            audioSource.PlayOneShot(sound1);
        }
    }
}
