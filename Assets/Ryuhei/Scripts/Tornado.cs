using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{

    public GameObject Player;
    bool HighJump = false;
    int HighJumpTime = 0;

    void Start()
    {
        //Player = GameObject.Find("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            HighJump = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            HighJump = false;
        }
    }

    void Update()
    {
        if (HighJump == true)
        {
            HighJumpTime += 1;
            Vector3 pos = Player.transform.position;
            pos.y += 0.60f;
            Player.transform.position = pos;
            Debug.Log("Tornado");
        }
        if (HighJumpTime >= 30)
        {
            HighJumpTime = 0;
            HighJump = false;
        }
    }
}
