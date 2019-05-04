﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene10Camera : MonoBehaviour
{
    public GameObject[] Screaming;
    public Texture[] StarGateTexture;
    public GameObject LeftStarGate;
    public GameObject RightStarGate;
    public int Delay = 0;
    public int ScreamIndex = 0;


    public float zRotate = 0;
    private float zRotation = 0;
    private bool NextScream = true;
    private float FieldOfView;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        zRotation += zRotate;
        transform.eulerAngles = new Vector3(0, 0, zRotation);

        if(NextScream == true)
        {
            NextScream = false;
            StartCoroutine("MoveScream");
        }


        Camera.main.fieldOfView += 0.01f;

    }

    IEnumerator MoveScream()
    {
        yield return new WaitForSeconds(Delay);
        Screaming[ScreamIndex].SetActive(true);
        //Change Texture of Star Gates.
        LeftStarGate.GetComponent<Renderer>().material.mainTexture = StarGateTexture[ScreamIndex + 1];
        RightStarGate.GetComponent<Renderer>().material.mainTexture = StarGateTexture[ScreamIndex + 1];

        //Rotate 
        zRotation += 90;

        //Increase FOV
        Camera.main.fieldOfView += 5f;

        //Remove screaming.
        yield return new WaitForSeconds(0.5f);
        Screaming[ScreamIndex].SetActive(false);
        NextScream = true;
        ScreamIndex++;
        //Do damage.
    }

}
