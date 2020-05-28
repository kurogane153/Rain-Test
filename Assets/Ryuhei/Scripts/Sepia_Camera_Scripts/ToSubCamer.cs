using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSubCamer : MonoBehaviour {

    private GameObject mainCamera;      //メインカメラ格納用

    // Use this for initialization
    void Start () {
        
        mainCamera = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(mainCamera.transform.position.x
            , mainCamera.transform.position.y, mainCamera.transform.position.z);

        Debug.Log(this.transform.position.x);
	}
}
