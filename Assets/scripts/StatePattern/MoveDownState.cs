using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownState : GameActorState
{
    public override void updateState(GameObject actor)
    {
        Vector3 dir = Vector3.down;
        actor.GetComponent<GameActorForStatePattern>().animator.SetBool("isMove", true);
        actor.transform.Translate(dir * actor.GetComponent<GameActorForStatePattern>().moveSpeed * Time.deltaTime);
    }
}
