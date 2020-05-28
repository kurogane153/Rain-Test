//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// このスクリプトがアタッチされたオブジェクトに触れたとき、カメラを切り変える
//public class CameraSwitching_OnObject : MonoBehaviour
//{

//    private GameObject mainCamera;      //メインカメラ格納用
//    private GameObject subCamera;       //サブカメラ格納用 

//    private GameObject Player;

//    private bool SepiaModeOFF = false;

//    //呼び出し時に実行される関数
//    void Start()
//    {
//        //メインカメラとサブカメラをそれぞれ取得
//        mainCamera = GameObject.Find("Main Camera");
//        subCamera = GameObject.Find("Sub Camera_sepia");
        
//        Player = GameObject.Find("Player");

//        // セピア調セット
//        //サブカメラをアクティブに設定
//        subCamera.SetActive(true);

//        //メインカメラを非アクティブに設定
//        subCamera.SetActive(false);
//    }


//    //単位時間ごとに実行される関数
//    void Update()
//    {
//        // セピア調セット
//        if (SepiaModeOFF == false)
//        {
//            //サブカメラをアクティブに設定
//            subCamera.SetActive(true);

//            //メインカメラを非アクティブに設定
//            subCamera.SetActive(false);
//        }

//        //// 通常調セット
//        //if (SepiaModeOFF == true)
//        //{
//        //    //メインカメラをアクティブに設定
//        //    subCamera.SetActive(true);

//        //    //サブカメラを非アクティブに設定
//        //    subCamera.SetActive(false);
//        //}

//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Player")
//        {
//            SepiaModeOFF = true;
//            Debug.Log("Stay_Sepia");
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Player")
//        {
//            SepiaModeOFF = false;
//        }
//    }
//}