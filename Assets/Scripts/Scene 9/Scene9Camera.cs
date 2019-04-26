using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene9Camera : MonoBehaviour
{

    //Variables.
    public GameObject LookAtTarget;
    public CameraLocations CameraLocationScript;
    public List<Vector3> CameraPos;

    //Private
    private bool ChangeCameraLocation = true;
    private int CameraNumber = 0;


    //Start is called before the first frame update
    void Start()
    {
        //Get the points that the camera will jump to.
        CameraPos = CameraLocationScript.CameraPos;
    }

    //Update is called once per frame
    void Update()
    {
        if(ChangeCameraLocation == true)
        {
            ChangeCameraLocation = false;
            StartCoroutine("ChangeLocation");
        }
    }

    IEnumerator ChangeLocation()
    {
        yield return new WaitForSeconds(20);
        transform.position = CameraPos[CameraNumber];
        CameraNumber++;
        transform.LookAt(LookAtTarget.transform.position);
        ChangeCameraLocation = true;
    }
}
