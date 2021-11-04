using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public float speed;
    public float length;
    public float weight;
    public float maxWaitTime;

    private float waitTime;

    private Vector2 originPosition;
    private Vector2 targetPosition;


    public new void Start() {
        // 调用父类的方法
        base.Start();
        originPosition = transform.position;
        targetPosition = GetRandomPos();
        waitTime = maxWaitTime;
    }

    public new void Update() {
        base.Update(); 

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);


        // TODO 判断移动路径上是否有障碍物
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f) {
            if (waitTime <= 0) {
                targetPosition = GetRandomPos();
                waitTime = maxWaitTime;
            }else {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos() {
        Vector2 position = new Vector2(Random.Range(originPosition.x-length, originPosition.x+length+1),
                                        Random.Range(originPosition.y-weight, originPosition.y+weight+1));
        return position;
    }
}
