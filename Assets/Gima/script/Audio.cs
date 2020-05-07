using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioClip sound1;
    AudioSource audioSource;
    bool flg = false;

    void Start () {

        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {

        if ((Input.GetAxis("Horizontal") >= 0.1f || Input.GetAxis("Horizontal") <= -0.1f) && flg == false)
        {
            audioSource.PlayOneShot(sound1);
            flg = true;
        }
        if((Input.GetAxis("Horizontal") == 0.0f || Input.GetAxis("Horizontal") == 0.0))
        {
            audioSource.Stop();
            flg = false;
        }
        if (Input.GetButton("X"))
        {
            audioSource.Stop();
            flg = true;
        }
    }
}
