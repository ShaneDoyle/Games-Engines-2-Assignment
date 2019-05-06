using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene5Background : MonoBehaviour
{
    //Update is called once per frame.
    void Update()
    {
        transform.Rotate(transform.up, 6 * Time.deltaTime, Space.World);
    }
}
