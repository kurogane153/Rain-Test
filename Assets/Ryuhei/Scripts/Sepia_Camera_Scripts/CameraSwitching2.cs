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
    private bool FinishSwitch = false;
    public static bool Res2 = false;
    private float PlayerPositionX;
    public float ThisEventOutPositionX; // この座標以上の位置にプレイヤーがいる時、このイベントをオフにする
    private bool SuperEndFadeOutSwitch; // このスイッチがオンの時、セピアからオフになっていく
    static public bool ThisEventOnTrigger = false; // このスイッチがオンの間、イベント中
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    subCamera.SetActive(true);
        //    Debug.Log("sepia");
        //}
        Res2 = true;
    }
    public static bool Res2nd()
    {
        return Res2;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        SuperFadeInSwitch = true;
    }
    private void FixedUpdate()
    {
        PlayerPositionX = Player.transform.position.x;
        if (PlayerPositionX <= ThisEventOutPositionX)
        {
            if (SuperFadeInSwitch == true && SuperEndFadeOutSwitch == false) // SuperEndFadeOutSwitch も条件につけるかも
            {
                ThisEventOnTrigger = true;
                panel.GetComponent<Image>().color = new Color(R, G, B, A);
                if (FadeInSwitch == false)
                {
                    A += 0.0075f;
                }
                if (A >= 1.0f && FadeInSwitch == false)
                {
                    FadeInSwitch = true;
                    subCamera.SetActive(true);
                    Debug.Log("SepiaTrue");
                }
                if (FadeInSwitch == true)
                {
                    A -= 0.0050f;
                }
                if (FadeInSwitch == true && A <= 0.0f)
                {
                    FadeInSwitch = false;
                    SuperEndFadeOutSwitch = true;
                    Debug.Log("0.0f");
                }
            }
            if (SuperEndFadeOutSwitch == true)
            {
                FinishFade();
            }
        }
        else
        {
            Finish();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FinishSwitch = true;
        }
    }
    private void FinishFade()
    {
        panel.GetComponent<Image>().color = new Color(R, G, B, A);
        if (FadeInSwitch == false)
        {
            A += 0.010f;
        }
        if (A >= 1.0f && FadeInSwitch == false)
        {
            subCamera.SetActive(false);
            FadeInSwitch = true;
        }
        if (FadeInSwitch == true)
        {
            A -= 0.010f;
        }
        if (FadeInSwitch == true && A <= 0.0f)
        {
            Finish();
        }
    }
    // 完全にフィニッシュする時
    private void Finish()
    {
        subCamera.SetActive(false);
        A = 0.0f;
        panel.GetComponent<Image>().color = new Color(R, G, B, A);
        FadeInSwitch = false;
        SuperFadeInSwitch = false;
        Destroy(this.gameObject);
        ThisEventOnTrigger = false;
        Debug.Log("sepiaOFF");
    }
}