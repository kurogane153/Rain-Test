using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitching2 : MonoBehaviour
{
    
    private GameObject subCamera;       //サブカメラ格納用 
    private GameObject Player;

    // RGBA変更
    private GameObject panel;
    private float R, G, B, A;
    private bool SuperFadeInSwitch = false;
    private bool FadeInSwitch = false;


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        subCamera = GameObject.Find("Sub Camera_sepia");

        //サブカメラを非アクティブにする
        subCamera.SetActive(false);

        Player = GameObject.Find("Player");

        // RGBA変更
        panel = GameObject.Find("Panel");

        R = panel.GetComponent<Image>().color.r;
        G = panel.GetComponent<Image>().color.g;
        B = panel.GetComponent<Image>().color.b;
        A = panel.GetComponent<Image>().color.a;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    subCamera.SetActive(true);
        //    Debug.Log("sepia");
        //}
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        SuperFadeInSwitch = true;
    }

    private void FixedUpdate()
    {
        if (SuperFadeInSwitch == true)
        {
            panel.GetComponent<Image>().color = new Color(R, G, B, A);

            if (FadeInSwitch == false)
            {
                A += 0.0050f;
            }

            if (A >= 1.0f && FadeInSwitch == false)
            {
                FadeInSwitch = true;
                subCamera.SetActive(true);
            }

            if (FadeInSwitch == true)
            {
                A -= 0.0050f;
                Debug.Log("-=0.0050");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Finish();
        }
    }

    private void Finish()
    {
        subCamera.SetActive(false);

        A = 0.0f;
        panel.GetComponent<Image>().color = new Color(R, G, B, A);
        FadeInSwitch = false;
        SuperFadeInSwitch = false;

        Destroy(this.gameObject);

        Debug.Log("sepiaOFF");
    }
}