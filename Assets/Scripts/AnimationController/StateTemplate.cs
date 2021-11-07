using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 状态拥有者
public class StateTemplate<T> : StateBase{
    public T owner; // 拥有者

    public StateTemplate(int id, T o): base(id) {
        owner = o;
    }
}
