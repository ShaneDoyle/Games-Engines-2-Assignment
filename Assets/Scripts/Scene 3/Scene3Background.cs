﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Background : MonoBehaviour
{
    //Variable
    private float xSpin = 0f;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up, 6 * Time.deltaTime, Space.World);
    }
}
