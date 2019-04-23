using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationScene2 : MonoBehaviour
{
    //Variables
    public float SpaceStationSpeed = 0.010f;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        transform.Translate(SpaceStationSpeed, 0f, 0.02f, Space.World);
    }
}
