using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Command : MonoBehaviour
{
    ~Command() { }
    abstract public void Execute(GameObject actor);

}
