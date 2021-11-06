using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance {get; private set;}

    public Transform target;
    public float smooth;

    public Animator animator;

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            Vector3 position = new Vector3(target.position.x, target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime*smooth);
        }
    }

    void LateUpdate() {
        
    }

    [Obsolete("Not recommended method", false)]
    public void Shake() {
        animator.SetTrigger("Shake");
    }
}
