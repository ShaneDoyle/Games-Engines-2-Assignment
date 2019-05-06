using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    //Start is called before the first frame update.
    void Start()
    {
        StartCoroutine("Scene2");
    }

    //To next scene.
    IEnumerator Scene2()
    {
        yield return new WaitForSeconds(24);
        SceneManager.LoadScene(1);
    }
}
