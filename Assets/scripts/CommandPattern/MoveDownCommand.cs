using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : Command
{
    public override void Execute(GameObject actor)
    {
        actor.GetComponent<GameActorForStatePattern>().MoveDown();

    }
}
