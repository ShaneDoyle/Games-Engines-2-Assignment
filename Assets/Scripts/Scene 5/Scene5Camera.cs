using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5Camera : MonoBehaviour
{
    //Public variables.
    public float CameraMovementSpeed = 0.001f;

    //Update is called once per frame.
    void Update()
    {
        transform.Translate(0, 0, CameraMovementSpeed, Space.World);
    }
}
