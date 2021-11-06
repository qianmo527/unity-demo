using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{

    public Rigidbody2D rigidbody2d;
    public BoxCollider2D myFeet;
    public Animator animator;
    
    [Header("Settings")]
    public string heroName;
    public float speed;
    public float jumpForce = 15;
    public bool isGrounded = false;
    public int maxJumpTime = 2;
    public int jumpTime;

    protected virtual void Awake() {
        Init();
        if (myFeet == null) {
            Debug.LogWarning("未加载脚部碰撞器 检测将不会触发");
        }
        Application.targetFrameRate = 90;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Flip();
        Move();
        Jump();
        Attack();
    }

    protected virtual void Init() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        jumpTime = maxJumpTime;
    }

    protected virtual void CheckGrounded() {
        if (myFeet != null)
            isGrounded = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    // 翻转人物贴图
    protected virtual void Flip() {
        bool hasSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
        if (hasSpeed) {
            if (rigidbody2d.velocity.x > 0.1f)
                transform.rotation = Quaternion.Euler(0, 0, 0);

            if (rigidbody2d.velocity.x < -0.1f)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // 移动方法
    protected virtual void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal*speed, rigidbody2d.velocity.y);
        rigidbody2d.velocity = velocity;
    }

    protected virtual void Jump() {
        // 检测跳跃状态
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpTime>0)) {
            if (jumpTime>0) {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y*0.1f);
                rigidbody2d.AddForce(jumpForce*Vector2.up, ForceMode2D.Impulse);
                jumpTime -= 1;
                isGrounded = false;
                return;
            }
        }else if (isGrounded && jumpTime != maxJumpTime) {
            jumpTime = maxJumpTime;
        }else {
            CheckGrounded();
        }
        //TODO 增加双击起飞特性
    }

    protected virtual void Attack() {}
}
