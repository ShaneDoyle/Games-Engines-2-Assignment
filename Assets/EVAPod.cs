using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVAPod : MonoBehaviour
{
    public GameObject Astronaut;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Astronaut.transform.position) < 2)
        {
            Astronaut.SetActive(false);
        }
    }
}
