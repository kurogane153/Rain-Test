using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMV : MonoBehaviour {

    private float P_X = 0.05f;
    Rigidbody2D rb2d;
    Animator _animator;
    //カメラで見てる↓
    public bool fix = false;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () { 
	}

    void FixedUpdate()
    {
        if (!fix)
        {
            transform.Translate(P_X, 0, 0);
            _animator.SetFloat("walk", 1.0f);
        }
        else
        {
            _animator.SetFloat("walk", 0.0f);
        }
        //this.transform.position = new Vector2(this.transform.position.x * P_X, rb2d.velocity.y);   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        fix = true;
    }
}
