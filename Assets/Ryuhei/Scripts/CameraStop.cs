using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour {

    private bool CameraStopSwitch = false;
    private GameObject mainCamera;
    private Vector3 Camera_pos;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera");
    }

    // カメラ停止ゾーンに入るとカメラを止める
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraStopSwitch = true;
            Camera_pos = mainCamera.transform.position;
        }
    }

    // カメラ停止解除
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraStopSwitch = false;
        }
        
    }

    // 実際にカメラを止める処理
    private void Update()
    {
        
        if (CameraStopSwitch == true)
        {
            mainCamera.transform.position = new Vector3(Camera_pos.x, Camera_pos.y, Camera_pos.z);
        }
        
    }

}
