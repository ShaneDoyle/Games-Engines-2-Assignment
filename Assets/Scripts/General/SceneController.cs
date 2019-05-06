using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //Public variables.
    public float NextSceneWait = 0f;
    public int SceneNumber = 1;

    //Start is called before the first frame update.
    void Start()
    {
        StartCoroutine("NextScene");
    }

    //Go to the next scene.
    IEnumerator NextScene()
    {
        //Depending on the wait time defined, go to the defined scene.
        yield return new WaitForSeconds(NextSceneWait);
        SceneManager.LoadScene(SceneNumber);
    }
}
