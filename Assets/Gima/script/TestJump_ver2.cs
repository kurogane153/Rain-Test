using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump_ver2 : MonoBehaviour {

    //角度ラインキャスト
    [SerializeField] private ContactFilter2D filter2D;

    //ラインキャストで地面にいるかどうかの判定に必要なやーつ
    public LayerMask groundLayer;
    Vector2 groundedStart;
    Vector2 groundedEnd;
    [Header("地面の当たり判定")]
    public bool isGrounded = false;

    //移動速度
    [Header("移動速度")]
    [SerializeField, Range(0f, 10f)]    private float speed=0.15f;

    //ジャンプキー入力
    //ジャンプの種類   0がY軸ジャンプ  ：　1がX軸ジャンプ

    private int jumpKey = 0;
    private float x;
    private float y;

    //自身のRigidbody
    Rigidbody2D rb2d;

    //ジャンプに必要なもの
    private bool isJumpingCheck = true;
    private bool isJumping = false;
    private float JumpPower;
    //乗った雨の種類　0なら通常 1なら高いジャンプ
    private int Raintype = 0;

    [Header("落下重力")]
    [SerializeField, Range(0f, 10f)]    private float gravityRate = 1.5f;

    [Header("軽減率")]
    [SerializeField, Range(0f, 10f)]
    private float jumpPowerAttenuation = 0.5f;

    [Header("ジャンプの高さ")]
    [SerializeField, Range(0f, 50f)]    private float JumpSpeed = 39;

    //ジャンプの許容値（Time）
    private float Jumpcnt = 0;
    //フルで飛べる秒数  Jumpcnt < MAX_COUNTなら飛べる
    private const float MAX_COUNT = 0.5f;

    [Header("現在設定されているリスポーンポイント")]
    public Vector3 restartPoint;

    [Header("何かしらの２Dオブジェクトに当たった時の判定")]
    public bool fix = false;

    [Header("デバッグモードがOnかOffか")]
    public bool Debug_F = false;

    [Header("ホワイトアウト用")]
    public bool Fade = false;

    private float grv = 0.0f;
    Animator _animator;
    public AudioClip sound1;
    AudioSource audioSource;
    private GameObject Parasol;
    private bool Parasol_flg = true;
    private GameObject DebugRes;
    //public bool Rainfix = false;

    [Header("パラソルを出した時の上昇補正用　rb2d.velocity.y <= parasol_line")]
    [SerializeField, Range(0f, 10f)] private float parasol_line = 5.0f;

    [Header("赤い雨に乗った時のジャンプ力　数値が大きいほど高く飛べる")]
    [SerializeField, Range(0f, 10f)] private float Rain_Red = 5.0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        restartPoint = this.transform.position;
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Parasol = GameObject.Find("Parasol");
        DebugRes = GameObject.Find("DebugRes");
    }

    void Update()
    {
        //デバッグモードがONになっているか
        if ((Input.GetButtonDown("Debug") || 
            Input.GetKeyDown(KeyCode.Backspace)) && Debug_F == false)
        {
            Debug_F = true;

        }
        else if ((Input.GetButtonDown("Debug") || 
            Input.GetKeyDown(KeyCode.Backspace)) && Debug_F == true)
        {
            Debug_F = false;
        }

        //デバッグモードがOFFなら
        if (!Debug_F)
        {
            //地面判定
            GroundEnter();
            //キー入力
            InputKey();
        }
        else
        {
            DebugMove();
            //デバッグ用
            Debug.DrawLine(groundedStart, groundedEnd, Color.red);
        }
    }

    void GroundEnter()
    {
        //地面判定取得
        //真下
        groundedStart = this.transform.position - this.transform.up * 1.2f;
        groundedEnd = this.transform.position + this.transform.up * 0.1f;
        isGrounded = Physics2D.Linecast(groundedStart, groundedEnd, groundLayer);
        isGrounded = rb2d.IsTouching(filter2D);
    }

    void InputKey()
    {
        //移動関連

        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -speed;
        }

        //アニメーション
        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        {
            if (jumpKey == 0)
            {
                _animator.SetFloat("walk", Input.GetAxis("Horizontal"));
            }

        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            _animator.SetFloat("walk", Input.GetAxis("Horizontal"));
        }

        // ジャンプキー取得
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("B") )
        {

            jumpKey = 1;

        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetButton("B"))
        {

            jumpKey = 2;

        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("B"))
        {

            jumpKey = 0;

        }

        //パラソルの入力判定
        if (!isGrounded)
        {
            if (Input.GetButtonDown("R1"))
            {
                if (!Parasol_flg)
                {
                    Parasol.gameObject.SetActive(true);
                    Parasol_flg = true;
                }
                else if (Parasol_flg)
                {
                    audioSource.PlayOneShot(sound1);
                    Parasol.gameObject.SetActive(false);
                    Parasol_flg = false;
                }
            }
        }
        if (isGrounded)
        {
            //地面にいるならパラソルを消す
            Parasol.gameObject.SetActive(false);
            Parasol_flg = false;
        }
    }

    //デバッグモードの移動処理
    void DebugMove()
    {
        bool keyflg=false;
        rb2d.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
            keyflg = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
            keyflg = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed, 0);
            keyflg = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed, 0);
            keyflg = true;
        }
        if (keyflg == false)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            gameObject.transform.position += new Vector3(x * speed, y * speed);
        }
        if (Input.GetButton("triangle"))
        {
            this.transform.position = DebugRes.transform.position;
        }
    }

    //2D当たり判定(すり抜け)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respaen")
        {
            restartPoint = collision.transform.position;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "fade")
        {
            Fade = true;
        }
    }

    //2D当たり判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        fix = true;
        if (collision.gameObject.tag == "Rain_Red")
        {
            Raintype = 1;
        }else if (collision.gameObject.tag == "Rain_White")
        {
            Raintype = 2;
        }
        else
        {
            Raintype = 0;
        }
    }

    //2D当たり判定（離れたら）
    void OnCollisionExit2D(Collision2D collision)
    {
        fix = false;
        //Raintype = 0;
    }

    //Unity内の指定回数毎秒回す
    void FixedUpdate()
    {
        if (!Debug_F)
        {
            _animator.SetBool("Jump", false);
            //横移動
            x = Input.GetAxis("Horizontal");
            gameObject.transform.position += new Vector3(x * speed, 0);

            //地面にいるとき
            if (isGrounded)
            {
                //飛べるかどうかのフラグがtrueかつジャンプキーが押されたら
                //各種フラグ,数値を代入
                if (isJumpingCheck)
                {
                    if (Jumpcnt < MAX_COUNT && jumpKey != 0)
                    {
                        isJumpingCheck = false;
                        isJumping = true;
                        if(Raintype == 2)
                        {
                            JumpPower = JumpSpeed;
                            grv = 1.0f;
                        }
                        //雨の種類で飛ばす高さを変える
                        if (Raintype == 0)
                        {
                            JumpPower = JumpSpeed;

                        }else if(Raintype == 1)
                        {
                            JumpPower = JumpSpeed;
                            JumpPower += Rain_Red;
                        }
                    }
                }
            }
            //地面にいない（空中にいる判定）
            else
            {
                _animator.SetBool("Jump", true);
                //ジャンプキーが離されたらジャンプ中のフラグをfalseにする
                if (jumpKey == 0)
                {
                    isJumping = false;
                }
                //veloctityが規定値より下回ったら重力を使って落とす
                if (jumpKey == 0 || Jumpcnt >= MAX_COUNT)
                {
                    if (Parasol_flg)
                    {
                        if (rb2d.velocity.y <= parasol_line)
                        {
                            rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y));
                        }
                        else
                        {
                            rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
                        }
                    }
                    else if (!Parasol_flg)
                    {
                        if (Raintype == 2)
                        {
                            if (rb2d.velocity.y <= parasol_line)
                            {
                                rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * grv));
                            }
                            else
                            {
                                rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
                            }
                        }
                        else
                        {
                            rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
                        }
                    }
                }
                //veloctityが規定値よりも上回っていたら
                else
                {
                    //ジャンプパワーがあるなら二倍の軽減率で減少させ飛ばす
                    if (0 <= JumpPower)
                    {
                        JumpPower -= jumpPowerAttenuation * 3;
                        rb2d.AddForce(new Vector2(rb2d.velocity.x, JumpPower));
                    }
                    //ないなら重力を使って落とす
                    else
                    {
                        if (Parasol_flg)
                        {
                            if (rb2d.velocity.y <= parasol_line)
                            {
                                rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y));
                            }
                            else
                            {
                                rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
                            }
                        }
                        else if (!Parasol_flg)
                        {
                            if (Raintype == 2)
                            {
                                if (rb2d.velocity.y <= parasol_line)
                                {
                                    rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * grv));
                                }
                                else
                                {
                                    rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
                                }
                            }
                            else
                            {
                                rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
                            }
                        }
                    }
                }
            }

            // ジャンプ中
            if (isJumping)
            {
                if (Jumpcnt < MAX_COUNT && jumpKey != 0)
                {
                    Jumpcnt += Time.deltaTime;
                    JumpPower -= jumpPowerAttenuation;
                    rb2d.AddForce(new Vector2(rb2d.velocity.x, JumpPower));
                }
                //飛べる秒数のカウンターが０になったらジャンプを解除する
                if (Jumpcnt >= MAX_COUNT)
                {
                    isJumping = false;
                }
                if (jumpKey == 0)
                {
                    isJumping = false;
                }
                //同様にvelocity.yが規定値よりも下回ったらジャンプを解除する
                if (rb2d.velocity.y < -1)
                {
                    isJumping = false;
                }
            }
            //ジャンプキーが離されたら飛べるかどうかのフラグをtrueにする
            if (jumpKey == 0)
            {
                isJumpingCheck = true;
                Jumpcnt = 0;
            }
        }
    }
}
