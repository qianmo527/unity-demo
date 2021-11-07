using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挂载在角色身上的脚本，用来控制状态机类

public enum PlayerState {
    None,
    Idle,
    Run,
    Attack
}

public class PlayerCtrl : MonoBehaviour {
    public Animation ani;
    public PlayerState ps = PlayerState.Idle;

    // 控制机器
    public StateMachine machine;

    void Start() {
        ani = GetComponent<Animation> ();

        IdleState idle = new IdleState (1, this);
        RunState run = new RunState (2, this);
        AttackState attack = new AttackState (3, this);

        machine = new StateMachine(idle);
        machine.AddState(run);
        machine.AddState(attack);
    }

    void Update () {
        if (Input.GetButtonDown("Attack")) {
            ps = PlayerState.Attack;
        }
        else if (Input.GetAxis("Horizontal") != 0) {
            ps = PlayerState.Run;
        }else ps = PlayerState.Idle;

        // 根据枚举 让状态机去切换状态
        UpdateAnimation();
    }

    private void UpdateAnimation() {
        switch (ps)
        {
            case PlayerState.Idle:
                machine.TranslateState(1);
                break;
            case PlayerState.Run:
                machine.TranslateState(2);
                break;
            case PlayerState.Attack:
                machine.TranslateState(3);
                break;
        }
    }

    void LateUpdate() {
        machine.Update();
    }
}
