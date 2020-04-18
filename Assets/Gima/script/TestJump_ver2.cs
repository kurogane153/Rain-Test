using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump_ver2 : MonoBehaviour {

    //角度ラインキャスト
    [SerializeField] private ContactFilter2D filter2D;
    public LayerMask groundLayer;

    //ラインキャストで地面にいるかどうかの判定に必要なやーつ
    Vector2 groundedStart;
    Vector2 groundedEnd;
    [Header("触らんで。致し方ない理由でpublicにしてます。すいません")]
    public bool isGrounded = false;

    //移動速度
    [Header("移動速度")]
    [SerializeField, Range(0f, 10f)]    private float speed=0.15f;

    //ジャンプキー入力
    private int jumpKey = 0;
    private float x;
    private float y;

    //private bool isLeftGrounded = true;
    //Vector2 leftgroundedStart;
    //Vector2 leftgroundedEnd;

    //private bool isRightGrounded = true;
    //Vector2 rightgroundedStart;
    //Vector2 rightgroundedEnd;

    //自身のRigidbody
    Rigidbody2D rb2d;

    //ジャンプに必要なもの
    private bool isJumpingCheck = true;
    private bool isJumping = false;
    private float JumpPower;

    [Header("落下重力")]
    [SerializeField, Range(0f, 10f)]    private float gravityRate = 1.5f;

    [Header("軽減率")]
    [SerializeField, Range(0f, 10f)]
    private float jumpPowerAttenuation = 0.5f;

    [Header("ジャンプの高さ")]
    [SerializeField, Range(0f, 50f)]    private float JumpSpeed = 39;

    //タメジャンプ
    private float Jumpcnt = 0;
    private const float MAX_COUNT = 0.5f;

    [Header("現在設定されているリスポーンポイント")]
    public Vector3 restartPoint;

    [Header("何かしらの２Dオブジェクトに当たった時の判定")]
    public bool fix = false;

    [Header("デバッグモードがOnかOffか")]
    public bool Debug_F = false;

    [Header("ホワイトアウト用")]
    public bool Fade = false;

    Animator _animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        restartPoint = this.transform.position;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
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

        if (!Debug_F)
        {
            GroundEnter();

            InputKey();
        }
        else
        {
            DebugMove();
            //デバッグ用
            Debug.DrawLine(groundedStart, groundedEnd, Color.red);
            //Debug.DrawLine(leftgroundedStart, leftgroundedEnd, Color.red);
            //Debug.DrawLine(rightgroundedStart, rightgroundedEnd, Color.red);
        }
    }

    void GroundEnter()
    {
        //地面判定取得
        //真下
        groundedStart = this.transform.position - this.transform.up * 1.2f;
        groundedEnd = this.transform.position + this.transform.up * 0.1f;
        isGrounded = Physics2D.Linecast(groundedStart, groundedEnd, groundLayer);
        ////左下
        //leftgroundedStart = this.transform.position - this.transform.right * 0.5f - this.transform.up * 1.2f;
        //leftgroundedEnd = this.transform.position + this.transform.up * 0.5f;
        //isLeftGrounded = Physics2D.Linecast(leftgroundedStart, leftgroundedEnd, groundLayer);
        ////右下
        //rightgroundedStart = this.transform.position - this.transform.right * -0.5f - this.transform.up * 1.2f;
        //rightgroundedEnd = this.transform.position + this.transform.up * 0.5f;
        //isRightGrounded = Physics2D.Linecast(rightgroundedStart, rightgroundedEnd, groundLayer);

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
        if (Input.GetButtonDown("X") || Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = 1;

        }
        else if (Input.GetButton("X") || Input.GetKey(KeyCode.Space))
        {
            jumpKey = 2;

        }
        else if (Input.GetButtonUp("X") || Input.GetKeyUp(KeyCode.Space))
        {

            jumpKey = 0;
        }
    }

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
    }

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        fix = true;   
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        fix = false;
    }

    void FixedUpdate()
    {
        if (!Debug_F)
        {
            _animator.SetBool("Jump", false);
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
                        JumpPower = JumpSpeed;
                        rb2d.AddForce(new Vector2(rb2d.velocity.x, JumpPower));
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
                    rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
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
                        rb2d.AddForce(new Vector2(rb2d.velocity.x, Physics.gravity.y * gravityRate * 2.5f));
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
