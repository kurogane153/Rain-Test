using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public bool fix = false;
    GameObject lever;

    void Start()
    {
        lever = GameObject.Find("lever");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (lever.gameObject.GetComponent<Switch>().fix == false)
        {
            fix = true;
        }   
    }
}
