using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //Variables
    public GameObject AerialCam;
    public GameObject MonkeyCam;

    private bool CamSwitch = true;

    //Start is called before the first frame update
    void Start()
    {
        MonkeyCam.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        if(CamSwitch == true)
        {
            CamSwitch = false;
            StartCoroutine("Camera");
        }
    }


    //Used on Death
    IEnumerator Camera()
    {
        AerialCam.SetActive(true);
        yield return new WaitForSeconds(4f);
        MonkeyCam.SetActive(true);
        yield return new WaitForSeconds(4f);
        AerialCam.SetActive(true);
        MonkeyCam.SetActive(false);
        yield return new WaitForSeconds(4f);
        CamSwitch = true;
    }
}
