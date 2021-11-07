using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Idle状态
public class IdleState : StateTemplate<PlayerCtrl>
{
    public IdleState(int id, PlayerCtrl p) : base(id, p){}

    public override void OnEnter(params object[] args)
    {
        base.OnEnter(args);
        owner.ani.Play("Idle");
    }
    public override void OnStay(params object[] args)
    {
        base.OnStay(args);
    }
    public override void OnExit(params object[] args)
    {
        base.OnExit(args);
    }
}
