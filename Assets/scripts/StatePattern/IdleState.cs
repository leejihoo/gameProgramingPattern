using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GameActorState
{
    public override void updateState(GameObject actor)
    {
        actor.GetComponent<GameActorForStatePattern>().animator.SetBool("isMove", false);
        actor.GetComponent<GameActorForStatePattern>().animator.SetBool("isAttack", false);
    }
}
