using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOperation : MonoBehaviour {

    SpriteRenderer MainSpriteRenderer;
    [Header("雨の速さ")]
    [SerializeField, Range(0,20f)] private float speed = 0.5f;
    [Header("当たり判定")]
    public bool fix = false;
    public Sprite mainsprite;
    public Sprite sabsprite;
    public GameObject particleObject;
    GameObject TW; // The_World_Itemオブジェクト

    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        TW = GameObject.Find("The_World_Item");
    }

    void Update ()
    {
        
    }

    void FixedUpdate()
    {
        RainMove();
    }

    void RainMove()
    {
        if (fix == false && TW.gameObject.GetComponent<The_World>().The_World_Switch != true)
        {
            this.transform.Translate(0, -speed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        fix = true;
        Vector3 pos;
        pos = this.transform.position;
        pos.y = this.transform.position.y + 0.5f;
        Instantiate(particleObject, pos, Quaternion.identity);
        MainSpriteRenderer.sprite = sabsprite;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        fix = false;
        MainSpriteRenderer.sprite = mainsprite;
    }

    void OnCollisionEnter(Collision collision)
    {
        fix = true;
    }

    void OnCollisionExit(Collision collision)
    {
        fix = false;
    }
}
