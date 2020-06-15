using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConntotororu : MonoBehaviour
{

    //カメラオブジェクト
    private GameObject mainCamera;
    //プレイヤーオブジェクト
    private GameObject Player;
    private GameObject feda;
    //z軸を調整。正の数ならプレイヤーの前に、負の数ならプレイヤーの後ろに配置する
    [Header("Z軸の補正")]
    [SerializeField, Range(-30f, 30f)]    private float zAdjust = -12.0f;
    [Header("Y軸の補正")]
    [SerializeField, Range(-30f, 30f)]    private float yAdjust = 5.0f;
    [Header("Y軸の補正(3Dオブジェクトに乗った場合の補正)")]
    [SerializeField, Range(-30f, 0f)]    private float yAdjust_3D = -5.0f;
    //回転補正
    [Header("X軸の補正(回転)")]
    [SerializeField, Range(-360f, 360f)] private float xRotation = 0.0f;
    //回転補正
    [Header("Y軸の補正(回転)")]
    [SerializeField, Range(-360f, 360f)] private float yRotation = 0.0f;
    //回転補正
    [Header("Z軸の補正(回転)")]
    [SerializeField, Range(-360f, 360f)] private float zRotation = 0.0f;

    //3D_Y軸補正用補完箱
    private float Y_Adjust = 0.0f;
    //Y座調整
    private float Y_camera = 0.0f;

    // カメラの移動につかうやつまとめ(Nodake)
    GameObject[] rains;
    private Vector3 pos_p;
    private bool fix; // 雨に触れたかどうか
    private bool fix2 = false;
    public bool CameraMoveSwitch = false;
    public bool fix3d;
    private bool tri = false;
    private bool floor = false;

    void Start()
    {
        Player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        feda = GameObject.Find("Fade");
        mainCamera.transform.Rotate(xRotation, yRotation, zRotation);
        Y_camera = Player.transform.position.y + yAdjust;
        mainCamera.transform.position = new Vector3(Player.transform.position.x, Y_camera, zAdjust);
    }

    void Update()
    {

        fix = false;

        pos_p = Player.gameObject.GetComponent<TestJump_ver2>().restartPoint;

        if (Player.gameObject.GetComponent<TestJump_ver2>().Debug_F == false)
        {
            PlayerOnGrand(); // プレイヤーが地面に立っているかどうか
            PlayerOnRain(); // プレイヤーが雨に当たっているかどうか
        }
        else
        {
            mainCamera.transform.position = new Vector3(Player.transform.position.x,
                Player.transform.position.y, zAdjust);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("triangle") || Input.GetKeyDown(KeyCode.T) ||
            feda.gameObject.GetComponent<FadeScript>().fed == true || GameOver.ris)
        {
            if (TestJump_ver2.st1)
            {
                pos_p = TestJump_ver2.pos_p;
                pos_p.z = zAdjust;
            }
            else
            {
                pos_p = TestJump_ver2.pos_p2;
                pos_p.z = zAdjust;
            }
            pos_p.z = zAdjust;
            if (floor)
            {
                pos_p.y += 5;
            }
            mainCamera.transform.position = pos_p;
            fix = true;
            tri = true;
            GameOver.ris = false;
        }

        CameraMoveOnRain(); // カメラが雨粒に乗ったときのうごき

        if (!fix2 && !tri)
        {
            mainCamera.transform.position = new Vector3(Player.transform.position.x,
               Y_camera , zAdjust);
        }
    }

    // プレイヤーが地面に触れているかどうか
    void PlayerOnGrand()
    {
        
        if (Player.transform.position.y <= -3.60f)
        {
            fix2 = false;
            if (Player.transform.position.y <= mainCamera.transform.position.y)
            {
                Y_camera = Player.transform.position.y + yAdjust;
            }
            if (Player.transform.position.y >= mainCamera.transform.position.y)
            {
                Y_camera = Player.transform.position.y + yAdjust;
            }
        }

        if (Player.transform.position.y <= 0.1f && CameraSwitching2.Res2)
        {
            fix2 = false;
            if (Player.transform.position.y <= mainCamera.transform.position.y)
            {
                Y_camera = Player.transform.position.y + yAdjust+10;
            }
            if (Player.transform.position.y >= mainCamera.transform.position.y)
            {
                Y_camera = Player.transform.position.y + yAdjust+10;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "floor") {
            fix3d = true;
            Y_Adjust = yAdjust_3D;
        }
        else if(collision.gameObject.tag == "floor")
        {
            floor = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        floor = false;
        fix3d = false;
        Y_Adjust = 0.0f;
    }

    // プレイヤーが雨に当たっているかどうか
    void PlayerOnRain()
    {
        rains = GameObject.FindGameObjectsWithTag("Rain");
        for (int i = 0; i < rains.Length; ++i)
        {
            if (rains[i].gameObject.GetComponent<RainOperation>().fix == true)
            {
                fix = true;
            }
        }

    }
    // カメラが雨粒に乗ったとき、移動する
    void CameraMoveOnRain()
    {
        CameraMoveSwitch = false;
        if (fix == true||fix3d == true)
        {
            CameraMoveSwitch = true; // カメラを移動する
            fix2 = true;
            tri = false;
        }

        // カメラを動かすスイッチがオンのとき
        if (CameraMoveSwitch == true)
        {
            if (Player.transform.position.y >= 0)
            {
                if (Player.transform.position.y >= mainCamera.transform.position.y + Y_Adjust)
                {
                    Y_camera = mainCamera.transform.position.y;
                    Y_camera += 0.10f;
                    mainCamera.transform.position = new Vector3(Player.transform.position.x, Y_camera , zAdjust);
                }
                if (Player.transform.position.y <= mainCamera.transform.position.y + Y_Adjust)
                {
                    Y_camera = mainCamera.transform.position.y;
                    Y_camera -= 0.10f;
                    mainCamera.transform.position = new Vector3(Player.transform.position.x, Y_camera , zAdjust);
                }
            }
        }
        else
        {
            fix2 = false;
        }
    }

}
