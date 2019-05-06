using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{

    //Variables.
    public Path path;
    public float Speed;
    public List<Vector3> waypoints;
    public int pathnum;

    //Private Variables
    private float Acc;
    private bool Coroutine = true;
    public bool FaceNextPoint = false;

    //Start is called before the first frame update
    void Start()
    {
        //Get the points that the GameObject will follow.
        waypoints = path.waypoints;
        Acc = Speed;
    }

    //Update is called once per frame
    void Update()
    {

        //Get position of the waypoint to move to.
        Vector3 dir = (waypoints[pathnum] - transform.position).normalized;

        //Go to the next way point.
        transform.position += dir * Acc * Time.deltaTime;



        //Turning
        if (FaceNextPoint == true)
        {
            Acc = 0;
            Vector3 targetPosition = new Vector3(waypoints[pathnum].x, waypoints[pathnum].y, waypoints[pathnum].z);
            Vector3 pos = waypoints[pathnum] - transform.position;
            Quaternion newRot = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 0.02f);
        }


        //Manage Acc.
        if (Vector3.Distance(waypoints[pathnum], transform.position) < Speed * 1.5f)
        {
            //Slow down.
            Acc = Mathf.Lerp(Acc, Speed * 0.1f, 0.02f);

        }
        else
        {
            //Speed up.
            if (Coroutine == true)
            {
                Acc = Mathf.Lerp(Acc, Speed, 0.02f);
            }
        }


        //Stop and face new point.
        if (Vector3.Distance(waypoints[pathnum], transform.position) < 1)
        {
            if (Coroutine == true)
            {
                Coroutine = false;
                StartCoroutine("Face");
            }
        }
    }

    IEnumerator Face()
    {
        pathnum++;
        FaceNextPoint = true;
        yield return new WaitForSeconds(Random.Range(6f, 6f));
        FaceNextPoint = false;
        Coroutine = true;

    }
}
