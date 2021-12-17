using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GameActorState
{
    public override void updateState(GameObject actor)
    {
        StartCoroutine(AttackDelay(actor));
    }

    IEnumerator AttackDelay(GameObject actor)
    {
        actor.GetComponent<GameActorForStatePattern>().animator.SetBool("isAttack", true);
        Debug.Log("°ø°Ýµô·¹ÀÌ");
        yield return new WaitForSeconds(1f);
    }
}
