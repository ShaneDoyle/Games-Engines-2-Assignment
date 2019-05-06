using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene10Camera : MonoBehaviour
{
    //Public variables.
    public GameObject[] Screaming;
    public Texture[] StarGateTexture;
    public GameObject LeftStarGate;
    public GameObject RightStarGate;
    public int StopIndex = 0;
    public int Delay = 0;
    public int ScreamIndex = 0;
    public float zRotate = 0;

    //Private variables.
    private float zRotation = 0;
    private bool NextScream = true;
    private float FieldOfView;

    //Update is called once per frame.
    void Update()
    {
        //Make Z rotation equal to the variable.
        zRotation += zRotate;
        transform.eulerAngles = new Vector3(0, 0, zRotation);

        //Go through all the screams.
        if(NextScream == true && ScreamIndex < Screaming.Length)
        {
            NextScream = false;
            StartCoroutine("MoveScream");
        }

        //Increase FOV.
        Camera.main.fieldOfView += 0.005f;

    }

    IEnumerator MoveScream()
    {
        yield return new WaitForSeconds(Delay);
        Screaming[ScreamIndex].SetActive(true);

        //Remove screaming.
        if (ScreamIndex < StopIndex)
        {
            //Change Texture of Star Gates.
            LeftStarGate.GetComponent<Renderer>().material.mainTexture = StarGateTexture[ScreamIndex];
            RightStarGate.GetComponent<Renderer>().material.mainTexture = StarGateTexture[ScreamIndex];

            //Rotate 
            zRotation += 90;

            //Increase FOV
            Camera.main.fieldOfView += 6f;

            yield return new WaitForSeconds(0.5f);
            Screaming[ScreamIndex].SetActive(false);
            NextScream = true;
            ScreamIndex++;
        }
    }
}
