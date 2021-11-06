using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aryan : Player
{
    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    protected override void Update()
    {
        base.Update();
        animator.SetFloat("y", rigidbody2d.velocity.y);
    }

    protected override void Move() {
        base.Move();
        bool hasSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon && Mathf.Approximately(animator.GetFloat("y"), 0);
        animator.SetBool("isRunning", hasSpeed);
    }

    protected override void Attack()
    {
        if (Input.GetButtonDown("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.SetTrigger("Attack");
        }
    }
}
