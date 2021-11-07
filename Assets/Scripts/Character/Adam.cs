using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adam : Player
{
    protected override void Update()
    {
        base.Update();
        Die();
        Defend();
    }

    protected override void Init()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    protected override void Flip()
    {
        if (Input.GetAxis("Horizontal") != 0) {
            transform.localScale = new Vector3(rigidbody2d.velocity.x>0 ? -1 : 1, 1, 1);
        }
    }

    protected override void Move()
    {
        base.Move();
        bool hasSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon && Mathf.Approximately(rigidbody2d.velocity.y, 0);
        animator.SetBool("hasSpeed", hasSpeed);
        animator.SetFloat("speed", rigidbody2d.velocity.x);
    }

    protected override void Jump()
    {
        base.Jump();
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpTime > 0)) {
            animator.SetTrigger("Jump");
        }
    }

    protected override void Attack()
    {
        if (Input.GetButtonDown("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.SetTrigger("Attack");
        }
    }

    private void Defend() {
        animator.SetBool("isDefending", Input.GetButton("Defend"));
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Defend")) {
            speed = 1.5f;
        }else speed = 5;
    }

    public void Sit() {
        animator.SetBool("isSitting", Input.GetButton("Sit"));
    }

    public void Die() {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&!animator.GetCurrentAnimatorStateInfo(0).IsName("Die")) animator.SetTrigger("Die");
    }
}
