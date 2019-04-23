using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3CameraMover : MonoBehaviour
{
    public float CameraMovementSpeed = 0.0003f;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, CameraMovementSpeed, Space.World);
    }
}
