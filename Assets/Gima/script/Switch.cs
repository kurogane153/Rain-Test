using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    GameObject efect;
    public bool fix = false;
    GameObject Swich;
    Animator _animator;
    GameObject HighVoltageLine;

    void Start () {
        efect = GameObject.Find("HighVoltageLine");
        Swich = GameObject.Find("Switch");
        HighVoltageLine = GameObject.Find("Death");
        _animator = Swich.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        fix = true;
        Destroy(HighVoltageLine);
        Destroy(efect);
        _animator.SetBool("key", true);
    }
}
