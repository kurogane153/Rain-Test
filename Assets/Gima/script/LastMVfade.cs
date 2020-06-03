using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastMVfade : MonoBehaviour {

    float alfa = 1.0f;
    private Image Img;
    private GameObject image_object;
    float speed = 0.01f;
    bool fast = false;
    bool fix = false;
    private GameObject Player;

    void Start () {
        image_object = GameObject.Find("Image");
        Img = image_object.GetComponent<Image>();
        Player = GameObject.Find("Player");
    }

	void Update () {
		
	}

    void FixedUpdate()
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
        if (Player.gameObject.GetComponent<LastMV>().fix == true)
        {
            Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, alfa);
            alfa += speed;
            if (alfa >= 1.0)
            {
                fix = true;
            }
        }
        if (fix)
        {
            SceneManager.LoadScene("LastMovie");
        }
    }
}
