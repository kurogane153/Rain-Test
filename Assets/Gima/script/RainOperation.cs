using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOperation : MonoBehaviour {

    SpriteRenderer MainSpriteRenderer;
    [SerializeField, Range(0,20f)] private float speed = 0.05f;
    public bool fix = false;
    public Sprite mainsprite;
    public Sprite sabsprite;

    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        if (fix == false)
        {
            this.transform.Translate(0, -speed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        fix = true;
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
