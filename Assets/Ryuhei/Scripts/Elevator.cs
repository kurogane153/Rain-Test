using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    public float speed, repeat_dist, delay;
    public int moveDirection;

    private float radian;
    private Vector3 defaultPositionBase;
    private Vector3 defaultPosition;
    private bool isMoving;
    private bool isMoving2;

    private Rigidbody2D rb; // this Rigidbody2D

    private GameObject Player;

    void Start()
    {
        defaultPositionBase = defaultPosition = transform.position;
        radian = 0;

        if (delay > 0)
        {
            StartCoroutine("startDelay", delay);
        }
        else
        {
            isMoving = true;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;

        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (isMoving)
        {
            switch (moveDirection) // 0:X方向 1:Y方向 2:Z方向
            {
                case 0:
                    transform.position = defaultPosition + new Vector3(Mathf.Sin(radian) * repeat_dist, 0, 0);
                    break;
                case 1:
                    transform.position = defaultPosition + new Vector3(0, Mathf.Sin(radian) * repeat_dist, 0);
                    break;
                case 2:
                    transform.position = defaultPosition + new Vector3(0, 0, Mathf.Sin(radian) * repeat_dist);
                    break;
                case 3:
                    if (this.transform.position.y < repeat_dist && isMoving2)
                    {
                        transform.position = defaultPosition + new Vector3(0, radian, 0);
                    }
                    else
                    {
                        transform.position = defaultPositionBase;
                        isMoving2 = false;
                    }
                    
                    break;
            }
            radian += speed * Time.deltaTime;
        }
    }

    IEnumerator startDelay(float time)
    {
        yield return new WaitForSeconds(time);
        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isMoving2 = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isMoving2 = true;
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