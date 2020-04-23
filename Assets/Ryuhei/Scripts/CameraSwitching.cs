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
    public float AreaY1 = 150.0f; //     ■■■■
    public float AreaY2 = 100.0f; //   Y2■■■■


    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera_sepia");

        //サブカメラを非アクティブにする
        //subCamera.SetActive(false);

        Player = GameObject.Find("Player");
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        

        // 指定エリア内にいる時のみセピア調
        if (AreaX1 <= Player.transform.position.x && Player.transform.position.x <= AreaX2 &&
            AreaY2 <= Player.transform.position.y && Player.transform.position.y <= AreaY1)
        {
                //サブカメラをアクティブに設定
                //mainCamera.SetActive(false);
                subCamera.SetActive(true);
                //Debug.Log("sepia");
        }
        else
        {
            //メインカメラをアクティブに設定
            subCamera.SetActive(false);
            //mainCamera.SetActive(true);
            //Debug.Log("Standard");
        }
    }
}