using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    float alfa;
    float alfa2 =0.0f;
    float alfa3 = 0.0f;
    float redin = 0;
    bool fade_F = false;

    [Header("フェードの速さ")]
    [SerializeField, Range(0f, 5f)] private float speed = 0.05f;

    [Header("死までの高さ調整")]
    [SerializeField, Range(-20, 0f)] private float dead = -5;

    float red, green, blue;
    Color color;
    private GameObject Player;
    private GameObject Main_camera;
    private bool flg = false;
    private Vector3 p_v;
    private bool triangle = false;
    public bool fed = false;

    //デバッグ
    [Header("デバッグモード用(ONならチェック)")]
    public bool debug;

    void Start()
    {
        color = GetComponent<Image>().color;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        Player = GameObject.Find("Player");
        Main_camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        //デバッグモードoffなら
        if (Player.gameObject.GetComponent<TestJump_ver2>().Debug_F == false)
        {
            //△かTキーが押されたら
            if (Input.GetButtonDown("triangle") || Input.GetKeyDown(KeyCode.T))
            {
                triangle = true;
            }
            ResPown();
            PlayerOnRain();
            Fade();
        }

        //ホワイトアウト
        if (Player.gameObject.GetComponent<TestJump_ver2>().Fade == true)
        {
            GetComponent<Image>().color = new Color(111111, 111111, 111111, alfa3);
            fade_F = true;
        } 

        if (fade_F)
        {
            GetComponent<Image>().color = new Color(111111, 111111, 111111, alfa3);
            alfa3 += 0.005f;
        }

        if (debug)
        {
            Debug.Log(Player.gameObject.GetComponent<TestJump_ver2>().Fade);
            Debug.Log(flg);
            Debug.Log(alfa);
            Debug.Log(alfa2);
        }
    }

    //地面（乗れるオブジェクトにいるかどうか）
    void PlayerOnRain()
    {
        //地面にいるかどうか
        if(Player.gameObject.GetComponent<TestJump_ver2>().isGrounded == true)
        {
            //地面（オブジェクトに乗っていたらポジションをセーブ）
            p_v = Player.transform.position;
            flg = false;
        }
        else
        {
            if (alfa < 1.0f)
            {
                flg = true;
            }
        }
    }

    //リスポーンポイントにリスポーンさせる
    void ResPown()
    {
        //フラグがONなら
        if (triangle)
        {
            //アルファ値を加算・フェードアウト
            if (alfa2 <=1.0f) {
                GetComponent<Image>().color = new Color(red, green, blue, alfa2);
                alfa2 += speed;
            }
            //アルファ値が規定値になったらリスポーンさせる
            if (alfa2 > 1.0f)
            {
                triangle = false;
                Player.transform.position = 
                    Player.gameObject.GetComponent<TestJump_ver2>().restartPoint;
            }
        } 
        //フラグがOff
        else if (!triangle)
        {
            triangle = false;
            //アルファ値が規定値以下なら
            if (alfa2 >= 0)
            {
                //アルファ値を減算・フェードイン
                GetComponent<Image>().color = new Color(red, green, blue, alfa2);
                alfa2 -= speed;
            }
        }
    }

    void Fade()
    {
        //フラグ（空中ならON）
        if (flg)
        {
            //現在のプレイヤーの位置　＜　セーブしてあるプレイヤーのY座標　+　既定の値
            if (Player.transform.position.y < p_v.y + (dead))
            {
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += speed;
            }
            if (alfa > 1.0f)
            {
                //リスポーン地点にリスポーンさせる
                Player.transform.position = 
                    Player.gameObject.GetComponent<TestJump_ver2>().restartPoint;
                fed = true;
                flg = false;
            }
        }else if (!flg)
        {
            //リスポーンフラグがOFFなら
            if (!triangle)
            {
                if (alfa >= 0)
                {
                    //フェードイン
                    GetComponent<Image>().color = new Color(red, green, blue, alfa);
                    alfa -= speed;
                    fed = false;
                }
                else if (alfa < 0)
                {
                    //フラグとアルファ値を初期代入
                    flg = false;
                    alfa = 0;
                }
            }
        }
    }
}