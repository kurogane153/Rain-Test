using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //シーン切り替えに使用するライブラリ

public class GateR2 : MonoBehaviour {

    float alfa;
    private float Rot = 0.0f;
    private GameObject Player;
    static public bool EDInisSwitch = false;
    private Image Img;
    private GameObject image_object;
    float speed = 0.01f;

    void Start()
    {
        Player = GameObject.Find("Player");
        image_object = GameObject.Find("Image");
        Img = image_object.GetComponent<Image>();
    }


    void Update()
    {

        if (167.50f <= Player.transform.position.x)
        {
            EDInisSwitch = true;
        }

        if (EDInisSwitch == true)
        {

            if (Rot >= -1.0f)
            {
                Rot -= 0.01f;
                this.gameObject.transform.Rotate(0, 0, Rot);

            }

            if (Rot < -0.50f)
            {
                if (alfa <= 1.0f)
                {
                    Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
                    alfa += speed;
                }
                else if (alfa > 1.0f)
                {
                    //FadeScript.ReStart = false;
                    TestJump_ver2.st1 = false;
                    EDInisSwitch = false;
                    SceneManager.LoadScene("SecondMovie");
                }
            }
        }
    }
}
