using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    GameObject efect;
    public bool fix = false;
    GameObject Swich;
    Animator _animator;

    void Start () {
        efect = GameObject.Find("HighVoltageLine");
        Swich = GameObject.Find("Switch");
        _animator = Swich.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        fix = true;
        Destroy(efect);
        _animator.SetBool("key", true);
    }
}
