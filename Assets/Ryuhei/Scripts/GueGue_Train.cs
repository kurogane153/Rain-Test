using UnityEngine;
using System.Collections;

public class GueGue_Train : MonoBehaviour
{

    public float speed;
    
    private Vector3 defaultPosition;
    private bool StartSwitch;

    //private Rigidbody2D rb; // this Rigidbody2D

    void Start()
    {
        
        
       

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
}