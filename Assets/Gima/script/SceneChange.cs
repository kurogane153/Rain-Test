using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour {

    public bool fed = false;
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
    }

	void Update ()
    {
        if (fed)
        {
            audioSource.PlayOneShot(sound1);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fed = true;
        }
    }
}
