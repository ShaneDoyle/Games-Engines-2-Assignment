using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSpaceship : MonoBehaviour
{
    //Variables
    public bool Reverse = false;

    // Update is called once per frame
    void Update()
    {
        if (Reverse == false)
        { 
            transform.Rotate(0, 0, -0.15f);
        }
        else
        {
            transform.Rotate(0, 0, 0.15f);
        }
    }
}


