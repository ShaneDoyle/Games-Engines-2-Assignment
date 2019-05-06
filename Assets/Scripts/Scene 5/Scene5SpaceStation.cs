using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5SpaceStation : MonoBehaviour
{
    //Public variables.
    public float CameraMovementSpeed = 0.005f;

    //Update is called once per frame.
    void Update()
    {
        transform.Translate(0, 0, CameraMovementSpeed, Space.World);
    }
}
