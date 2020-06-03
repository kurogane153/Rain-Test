using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    float alfa = 0.0f;
    bool flg = false;
    bool flg2 = false;
    private Image Img;
    private GameObject image_object;
    private static Vector3 pos_p;
    private static bool res;

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
                pos_p = TestJump_ver2.pos();
                res = FadeScript.Res();
                SceneManager.LoadScene("Rain_Main_ForR");
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

    public void ReStartButton()
    {
        flg = true;
    }

    public void TitleButton()
    {
        flg2 = true;
    }
}
