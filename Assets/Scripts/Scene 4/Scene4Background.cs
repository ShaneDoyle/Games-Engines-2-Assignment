using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Background : MonoBehaviour
{
    //Update is called once per frame.
    void Update()
    {
        transform.Translate(0f, 0.005f, 0f, Space.World);
    }
}
