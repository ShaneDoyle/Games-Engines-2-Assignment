using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVAPod : MonoBehaviour
{
    public GameObject Astronaut;
    public GameObject EVAAstronaut;
    public PathFollow PathScript;
    public AudioSource PodBayDoors;


    public int PathNum = 0;
    private bool PlaySound = true;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //Pathnum
        PathNum = PathScript.pathnum;

        if(PathNum >= 9)
        {
            if(PlaySound == true)
            {
                PlaySound = false;
                PodBayDoors.Play();
            }
        }

        //Remove Astronaut.
        if(Vector3.Distance(transform.position, Astronaut.transform.position) < 2)
        {
            Astronaut.SetActive(false);
            EVAAstronaut.SetActive(true);
        }
    }
}
