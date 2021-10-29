using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float doublejumpSpeed;
    public bool isGround;
    private bool canDoubleJump;

    public Rigidbody2D rigidbody2d;
    public BoxCollider2D myFeet;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Move();
        Jump();
        CheckGrounded();

        animator.SetFloat("y", rigidbody2d.velocity.y);
    }

    void CheckGrounded() {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void Flip() {
        bool hasSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
        if (hasSpeed) {
            if (rigidbody2d.velocity.x > 0.1f)
                transform.rotation = Quaternion.Euler(0, 0, 0);

            if (rigidbody2d.velocity.x < -0.1f)
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal*speed, rigidbody2d.velocity.y);
        rigidbody2d.velocity = velocity;
        bool hasSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon && Mathf.Approximately(animator.GetFloat("y"), 0);
        animator.SetBool("isRunning", hasSpeed);
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && isGround) {
            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
            rigidbody2d.velocity = Vector2.up * jumpVel;
            canDoubleJump = true;
        }else if(Input.GetButtonDown("Jump") && !isGround) {
            if (canDoubleJump) {
                Vector2 doublejumpVel = new Vector2(0.0f, doublejumpSpeed);
                rigidbody2d.velocity = Vector2.up * doublejumpVel;
                canDoubleJump = false;
            }
        }
    }
}
