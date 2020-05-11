using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpontherain : MonoBehaviour {

    Animator _animator;
    private GameObject Player;

    void Start () {

		Player = GameObject.Find("Player");
        _animator = GetComponent<Animator>();

    }

	void Update () {

        //Player.gameObject.GetComponent<TestJump_ver2>().isGrounded &&

        if (Player.gameObject.GetComponent<TestJump_ver2>().fix)
        {
            this.transform.position = Player.transform.position;
            _animator.SetBool("on the Rain", true);
        }
        else if (Player.gameObject.GetComponent<TestJump_ver2>().fix == false)
        {
            _animator.SetBool("on the Rain", false);
        }

	}
}
