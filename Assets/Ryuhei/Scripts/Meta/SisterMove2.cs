using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterMove2 : MonoBehaviour
{

    private bool ThisEventTrigger = false;
    private int Timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ThisEventTrigger == true)
        {
            transform.position += new Vector3(0, Mathf.Sin(Timer / 30) * 0.050f, 0);


            if (++Timer >= 180)
            {

                // transformを取得
                Transform myTransform = this.transform;

                // 座標を取得
                Vector3 pos = myTransform.position;
                pos.x += 0.05f;    // x座標へ0.01加算
                pos.y += 0.05f;    // x座標へ0.01加算

                myTransform.position = pos;  // 座標を設定

                // 徐々にこの画像をフェードアウトする
                UnityEngine.Color tmp = this.GetComponent<SpriteRenderer>().color;
                tmp.a = tmp.a -= 0.0050f;
                this.GetComponent<SpriteRenderer>().color = tmp;
            }
            if (Timer >= 480)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ThisEventTrigger = true;
    }



}
