using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : Command
{
    public override void Execute(GameObject actor)
    {
        actor.GetComponent<GameActor>().MoveUp();

    }
}
