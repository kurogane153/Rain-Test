using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{

    private GameObject mainCamera;      //メインカメラ格納用
    private GameObject subCamera;       //サブカメラ格納用 

    private GameObject Player;

    // カメラの位置
    public float AreaX1 = 128.0f; // X1Y1■■■■X2
    public float AreaX2 = 150.0f; //     ■■■■
    //public float AreaY1 = 150.0f; //     ■■■■
    //public float AreaY2 = 100.0f; //   Y2■■■■


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera_sepia");

        //サブカメラを非アクティブにする
        subCamera.SetActive(false);

        Player = GameObject.Find("Player");
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        //if (Player.transform.position.x < AreaX1 || AreaX2 < Player.transform.position.x ||
        //    Player.transform.position.y < AreaY2 || AreaY1 < Player.transform.position.y)
        //{
        //    //サブカメラを非アクティブに設定
        //    subCamera.SetActive(false);
        //}


        //if (AreaX1 - 2.0f <= Player.transform.position.x && Player.transform.position.x <= AreaX2 + 2.0f
        //    /*&& AreaY2 - 4.0f <= Player.transform.position.y && Player.transform.position.y <= AreaY1 + 4.0f*/)
        //{



        //    if (Player.transform.position.x < AreaX1 || AreaX2 < Player.transform.position.x
        //        /*&& Player.transform.position.y < AreaY2 &&  AreaY1 < Player.transform.position.y*/)
        //    {
        //        //サブカメラを非アクティブに設定
        //        subCamera.SetActive(false);
        //        Debug.Log("sepia");
        //    }
        //}



        subCamera.SetActive(false);




        // 指定エリア内にいる時のみセピア調
        if (AreaX1 <= Player.transform.position.x && Player.transform.position.x <= AreaX2 
            /*&& AreaY2 <= Player.transform.position.y && Player.transform.position.y <= AreaY1*/)
        {
            //サブカメラをアクティブに設定
            subCamera.SetActive(true);
            //Debug.Log("sepia");
        }


    }
}