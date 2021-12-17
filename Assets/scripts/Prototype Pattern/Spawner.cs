using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject unit;
    Transform tr;

    

    public void CreateUnit()
    {
        GameObject obj = Instantiate(unit);
        obj.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5, 5f), 0);
        
    }
}

