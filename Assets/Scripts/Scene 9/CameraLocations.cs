using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocations : MonoBehaviour
{
    //Public variables.
    public List<Vector3> CameraPos = new List<Vector3>();
    public int next = 0;
    public bool looped = true;

    //Draw each camera point.
    public void OnDrawGizmos()
    {
        int count = looped ? (transform.childCount + 1) : transform.childCount;
        Gizmos.color = Color.red;
        for (int i = 1; i < count; i++)
        {
            Transform prev = transform.GetChild(i - 1);
            Transform next = transform.GetChild(i % transform.childCount);
            Gizmos.DrawSphere(prev.position, 1);
            Gizmos.DrawSphere(next.position, 1);
        }
    }

    //Start is called before the first frame update.
    void Start()
    {
        CameraPos.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            CameraPos.Add(transform.GetChild(i).position);
        }
    }
}
