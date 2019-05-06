using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EVAPod : MonoBehaviour
{
    //Public variables.
    public GameObject Astronaut;
    public GameObject EVAAstronaut;
    public PathFollow PathScript;
    public AudioSource PodBayDoors;
    public AudioSource Eerie;
    public AudioSource Beeping;
    public GameObject FadeOut;
    public int PathNum = 0;

    //Private variables.
    private bool PlaySound = true;
    private bool LoadScene = true;

    //Update is called once per frame.
    void Update()
    {
        //Pathnum
        PathNum = PathScript.pathnum;

        //Reduce music volume.
        if (PathNum >= 8)
        {
            Eerie.volume -= 0.001f;
            Beeping.volume -= 0.001f;
            if(LoadScene == true)
            {
                LoadScene = false;
                StartCoroutine("NextScene");
            }
        }

        //Play sound.
        if (PathNum >= 9)
        {
            if(PlaySound == true)
            {
                PlaySound = false;
                PodBayDoors.Play();
                FadeOut.SetActive(true);
            }
        }

        //Remove Astronaut.
        if(Vector3.Distance(transform.position, Astronaut.transform.position) < 2)
        {
            Astronaut.SetActive(false);
            EVAAstronaut.SetActive(true);
        }
    }

    //Next scene, when reached back to final point.
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene(10);
    }

}
