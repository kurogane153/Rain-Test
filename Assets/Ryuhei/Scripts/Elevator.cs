using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{

    public float speed, repeat_dist, delay;
    public int moveDirection;

    private float radian;
    private Vector3 defaultPosition;
    private bool isMoveing;

    private Rigidbody2D rb; // this Rigidbody2D

    void Start()
    {
        defaultPosition = transform.position;
        radian = 0;

        if (delay > 0)
        {
            StartCoroutine("startDelay", delay);
        }
        else
        {
            isMoveing = true;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (isMoveing)
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
            }
            radian += speed * Time.deltaTime;
        }
    }

    IEnumerator startDelay(float time)
    {
        yield return new WaitForSeconds(time);
        isMoveing = true;
    }
}