﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background2 : MonoBehaviour
{
    //Update is called once per frame.
    void Update()
    {
        transform.Translate(0.04f, 0f, 0.02f, Space.World);
    }
}
