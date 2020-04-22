using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect_sepia : MonoBehaviour {

    //public Material Standard;
    public Material sepia;
    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        this.transform.position = new Vector3(mainCamera.transform.position.x,
            mainCamera.transform.position.y, mainCamera.transform.position.z);
    }


    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, sepia);
    }
}
