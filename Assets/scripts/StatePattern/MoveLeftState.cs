using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftState : GameActorState
{
    public override void updateState(GameObject actor)
    {
        Vector3 dir = Vector3.left;
        var actor_ = actor.GetComponent<GameActorForStatePattern>();
        actor_.animator.SetBool("isMove", true);
        // 스프라이트 반전
        if (actor.transform.localScale.x > 0)
        {
            actor.transform.localScale = new Vector3(actor.transform.localScale.x * -1f, actor.transform.localScale.y, actor.transform.localScale.z);
        }
        actor.transform.Translate(dir * actor_.moveSpeed * Time.deltaTime);
    }
}
