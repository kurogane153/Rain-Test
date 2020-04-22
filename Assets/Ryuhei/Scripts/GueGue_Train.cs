using UnityEngine;
using System.Collections;

public class GueGue_Train : MonoBehaviour
{

    public float speed;
    
    private Vector3 defaultPosition;
    private bool StartSwitch;

    private GameObject Player;

    //private Rigidbody2D rb; // this Rigidbody2D

    void Start()
    {


        Player = GameObject.Find("Player");

        //rb = GetComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {

        // あひるの再生成
        if (this.transform.position.y <= 30.0f)
        {
            StartSwitch = false;
            transform.position = new Vector3(147, 112.0f, 0.0f);
        }

        if (StartSwitch == true)
        {
            defaultPosition = transform.position;
            transform.position = defaultPosition + new Vector3(speed, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartSwitch = true;
            Debug.Log("GueGue");
        }
    }

    // 乗っている間プレイヤーをthisの子要素にする
    private void OnCollisionStay2D(Collision2D collision)
    {
        Player.transform.parent = this.transform;
    }

    // 降りたら子要素解除
    private void OnCollisionExit2D(Collision2D collision)
    {
        Player.transform.parent = null;
    }
}