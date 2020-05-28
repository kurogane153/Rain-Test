using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching2 : MonoBehaviour
{
    
    private GameObject subCamera;       //サブカメラ格納用 

    private GameObject Player;

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        subCamera = GameObject.Find("Sub Camera_sepia");

        //サブカメラを非アクティブにする
        subCamera.SetActive(false);

        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            subCamera.SetActive(true);
            Debug.Log("sepia");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            subCamera.SetActive(false);
            Debug.Log("sepiaOFF");
        }
    }
}