using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attack状态
public class AttackState : StateTemplate<PlayerCtrl>
{
    public AttackState(int id, PlayerCtrl p): base(id, p) {}

    public override void OnEnter(params object[] args)
    {
        base.OnEnter(args);
        owner.ani.Play("Attack");
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
