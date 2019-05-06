using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //Variables.
    public GameObject LookTarget;

    //Update is called once per frame.
    void Update()
    {
        transform.LookAt(LookTarget.transform);
    }
}
