using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour {

    public bool fix = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fix = true;
        }
    }
}
