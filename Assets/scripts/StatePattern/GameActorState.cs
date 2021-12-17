using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GameActorState : MonoBehaviour
{
    ~GameActorState() { }
    //abstract public void handleInput(GameObject actor);
    abstract public void updateState(GameObject actor);
}
