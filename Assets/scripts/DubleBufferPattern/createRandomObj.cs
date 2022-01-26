using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRandomObj : MonoBehaviour
{
    public GameObject actor;
    GameObject obj;
    Vector3 vec3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("auto");
        for (int i = 0; i < 500; i++)
        {
            vec3 = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            obj = Instantiate(actor);
            obj.transform.position = vec3;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void create()
    {
   
    }
}
