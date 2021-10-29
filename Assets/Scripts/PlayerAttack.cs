using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;

    public Animator animator;
    public PolygonCollider2D collider2d; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // TODO switch
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy>().GiveDamage(damage);
        }
    }

    void Attack() {
        if (Input.GetButtonDown("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.SetTrigger("Attack");
        }
    }
}
