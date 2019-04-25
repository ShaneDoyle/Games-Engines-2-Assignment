using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public float NextSceneWait = 0f;
    public int SceneNumber = 1;
    private GameObject Audio = null;

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine("NextScene");
        //SceneNumber--; //Adjust scene number to actually load the correct one.
    }


    //Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(NextSceneWait);
        SceneManager.LoadScene(SceneNumber);
    }
}
