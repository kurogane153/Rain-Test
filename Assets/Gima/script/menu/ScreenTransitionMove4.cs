using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenTransitionMove4 : MonoBehaviour {

    float alfa = 1.0f;
    bool flg = false;
    bool fast = false;
    private Image Img;
    private GameObject image_object;

    float speed = 0.05f;

    void Start()
    {
        image_object = GameObject.Find("Image");
        Img = image_object.GetComponent<Image>();
    }

    void Update()
    {
        if (alfa >= 0 && !fast)
        {
            Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
            alfa -= speed;
        }
        else
        {
            fast = true;
        }
        if (flg && fast)
        {
            if (alfa <= 1.0f)
            {
                Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
                alfa += speed;
            }
            else if (alfa > 1.0f)
            {
                fast = false;
                SceneManager.LoadScene("Title");
            }
        }
    }

    public void PushButton()
    {
        flg = true;
    }
}
