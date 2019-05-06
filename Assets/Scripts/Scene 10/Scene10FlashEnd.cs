using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene10FlashEnd : MonoBehaviour
{
    //Public variables.
    public GameObject LightingSound;

    //Start is called before the first frame update.
    void Start()
    {
        StartCoroutine("EndScene");
    }

    //End the scene after the flash.
    IEnumerator EndScene()
    {
        //End scene and load next.
        LightingSound.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(11);
    }
}
