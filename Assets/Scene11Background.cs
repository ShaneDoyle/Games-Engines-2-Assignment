﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene11Background : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0.008f, 0f, Space.World);
    }
}
