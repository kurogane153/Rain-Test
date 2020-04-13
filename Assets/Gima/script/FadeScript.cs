using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    float alfa;
    float alfa2 =0.0f;
    [SerializeField, Range(0f, 5f)] private float speed = 0.05f;

    [Header("死までの高さ調整")]
    [SerializeField, Range(-20, 0f)] private float dead = -5;

    float red, green, blue;
    Color color;
    private GameObject Player;
    private bool flg = false;
    private Vector3 p_v;
    public bool res = false;
    public bool triangle = false;
    private bool fed = false;

    //デバッグ
    public bool debug;

    void Start()
    {
        color = GetComponent<Image>().color;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Player.gameObject.GetComponent<TestJump_ver2>().Debug_F == false)
        {
            if (Input.GetButtonDown("triangle") || Input.GetKeyDown(KeyCode.T))
            {
                triangle = true;
            }
            ResPown();
            PlayerOnRain();
            Fade();
        }

        if (debug)
        {
            Debug.Log(flg);
            Debug.Log(alfa);
            Debug.Log(alfa2);
        }
    }

    void PlayerOnRain()
    {
        if(Player.gameObject.GetComponent<TestJump_ver2>().fix == true)
        {
            p_v = Player.transform.position;
            flg = false;
        }
        else
        {
            if (alfa < 1.0f)
            {
                flg = true;
            }
        }
    }

    void ResPown()
    {
        
        if (triangle)
        {
            if (alfa2 <=1.0f) {
                GetComponent<Image>().color = new Color(red, green, blue, alfa2);
                alfa2 += speed;
            }
            if (alfa2 > 1.0f)
            {
                triangle = false;
                Player.transform.position = Player.gameObject.GetComponent<TestJump_ver2>().restartPoint;
            }
        } 
        else if (!triangle)
        {
            triangle = false;
            if (alfa2 >= 0)
            {
                GetComponent<Image>().color = new Color(red, green, blue, alfa2);
                alfa2 -= speed;
            }
        }
    }

    void Fade()
    {
        if (flg)
        {
            if (Player.transform.position.y < p_v.y + (dead))
            {
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += speed;
                fed = true;
            }
            if (alfa > 1.0f)
            {
                Player.transform.position = Player.gameObject.GetComponent<TestJump_ver2>().restartPoint;
                flg = false;
            }
        }else if (!flg)
        {
            if (!triangle)
            {
                if (alfa >= 0)
                {
                    GetComponent<Image>().color = new Color(red, green, blue, alfa);
                    alfa -= speed;
                }
                else if (alfa < 0)
                {
                    flg = false;
                    alfa = 0;
                }
            }
        }
    }
}