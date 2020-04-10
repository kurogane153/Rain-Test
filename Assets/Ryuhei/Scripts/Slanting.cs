using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 雨(自身)を斜めに動かす
public class Slanting : MonoBehaviour
{

    private bool Lock = false;
    public float AreaX1 = 30.0f; // X1Y1■■■■X2
    public float AreaX2 = 40.0f; //     ■■■■
    public float AreaY1 = 40.0f; //     ■■■■
    public float AreaY2 = 0.0f;  //   Y2■■■■
    public float RainRot = -10.0f; // 雨の回転角度

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // 指定エリア内にいる時のみ斜め移動
        if (AreaX1 <= this.transform.position.x && this.transform.position.x <= AreaX2)
        {
            if (AreaY2 <= this.transform.position.y && this.transform.position.y <= AreaY1)
            {
                if (Lock == false)
                {
                    // 回転
                    //this.transform.LookAt(new Vector3(0, 0, 330));

                    // トランスフォームを取得
                    Transform myTransform = this.transform;

                    myTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, RainRot));

                    //// 自身の移動
                    //Vector3 pos = this.transform.position;
                    //pos.x -= 0.020f;
                    //myTransform.position = pos;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Lock = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Lock = false;
        }
    }

}
