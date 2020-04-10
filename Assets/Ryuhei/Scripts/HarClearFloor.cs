using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarClearFloor : MonoBehaviour {

    bool setPass;
    BoxCollider2D colliderOfPass;

    // Use this for initialization
    void Start()
    {
        colliderOfPass = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (setPass)
        {
            colliderOfPass.enabled = false;
        }
        if (!setPass)
        {
            colliderOfPass.enabled = true;
        }
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            setPass = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            setPass = false;
        }
    }
}
