﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour {

    float alfa = 0.0f;
    bool flg = false;
    bool flg2 = false;
    private Image Img;
    private GameObject image_object;
    public static bool title = true;

    float speed =0.05f;

    void Start()
    {
        image_object = GameObject.Find("Image");
        Img = image_object.GetComponent<Image>();
        TestJump_ver2.st1 = false;
        CameraSwitching2.Res2 = false;
    }

    void Update()
    {
        if (flg)
        {
            if (alfa <= 1.0f)
            {
                Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
                alfa += speed;
            }
            else if (alfa > 1.0f)
            {
                title = true;
                SceneManager.LoadScene("FastMovie");
            }
        }
        if (flg2)
        {
            if (alfa <= 1.0f)
            {
                Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
                alfa += speed;
            }
            else if (alfa > 1.0f)
            {
                SceneManager.LoadScene("Credit");
            }
        }
    }

    public void PushButton()
    {
        flg = true;
    }

    public void EndGame()
    {
        flg2 = true;
    }
}
