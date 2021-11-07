using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Run状态
public class RunState : StateTemplate<PlayerCtrl> {
    public RunState(int id, PlayerCtrl p): base(id, p) {}

    public override void OnEnter(params object[] args)
    {
        base.OnEnter(args);
        owner.ani.Play("Run");
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
