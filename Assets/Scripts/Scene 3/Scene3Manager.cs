using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{
    //Start is called before the first frame update.
    void Start()
    {
        StartCoroutine("Scene3");
    }

    //Go to next scene...
    IEnumerator Scene3()
    {
        yield return new WaitForSeconds(40);
        SceneManager.LoadScene(3);
    }
}
