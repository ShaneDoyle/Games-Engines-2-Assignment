using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Background : MonoBehaviour
{
    //Private variables.
    private float SpinSpeed = 6f;

    //Update is called once per frame.
    void Update()
    {
        transform.Rotate(transform.up, SpinSpeed * Time.deltaTime, Space.World);
    }
}
