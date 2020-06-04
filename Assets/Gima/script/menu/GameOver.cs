using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    float alfa = 0.0f;
    bool flg = false;
    bool flg2 = false;
    public static bool res2;
    private Image Img;
    private GameObject image_object;
    public static Vector3 pos_p;
    public static Vector3 pos2_p;
    public static bool res;

    float speed = 0.05f;

    void Start () {
        image_object = GameObject.Find("Image");
        Img = image_object.GetComponent<Image>();
    }
	

	void Update () {

        if (flg)
        {
            if (alfa <= 1.0f)
            {
                Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
                alfa += speed;
            }
            else if (alfa > 1.0f)
            {
                //pos_p = TestJump_ver2.pos();
                //res = FadeScript.Res();
                //res = FadeScript.Res();
                //res2 = CameraSwitching2.Res2nd();
                if (CameraSwitching2.Res2)
                {
                    //pos2_p = TestJump_ver2.pos2();
                    TestJump_ver2.st1 = false;
                    //Debug.Log(CameraSwitching2.Res2);
                    SceneManager.LoadScene("NewStage2");
                }
                else if(TestJump_ver2.st1)
                {
                    //pos_p = TestJump_ver2.pos();
                    //Debug.Log(TestJump_ver2.st1);
                    SceneManager.LoadScene("Rain_Main_ForR");
                }
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
                SceneManager.LoadScene("Title");
            }
        }
    }

    public static bool Res_G()
    {
        return res;
    }


    public static Vector3 pos_G()
    {
        return pos_p;
    }

    public static Vector3 pos2_G()
    {
        return pos2_p;
    }

    public void ReStartButton()
    {
        flg = true;
    }

    public void TitleButton()
    {
        flg2 = true;
    }
}
