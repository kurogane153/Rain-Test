using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_World : MonoBehaviour
{

    public bool The_World_Switch = false;
    public const int THE_WORLD_TIME = 200; // 参照用 6秒くらい
    private int The_World_Time = THE_WORLD_TIME; // 時止め時間

    // ザ・ワールド
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            The_World_Switch = true;
            Debug.Log("The_World");
        }
    }

    void FixedUpdate()
    {
        if (The_World_Switch == true)
        {
            The_World_Time -= 1;
            if (The_World_Time <= 0)
            {
                The_World_Switch = false;
                The_World_Time = THE_WORLD_TIME;
            }
        }

    }

}
