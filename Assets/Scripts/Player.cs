using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce = 7;
    public bool isGrounded;
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
        isGrounded = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
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
        
    }
}
