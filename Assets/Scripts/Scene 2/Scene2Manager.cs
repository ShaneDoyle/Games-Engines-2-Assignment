using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene2Manager : MonoBehaviour
{
    //Start is called before the first frame update.
    void Start()
    {
        StartCoroutine("Scene3");
    }

    //Go to scene 3.
    IEnumerator Scene3()
    {
        yield return new WaitForSeconds(13);
        SceneManager.LoadScene(2);
    }
}
