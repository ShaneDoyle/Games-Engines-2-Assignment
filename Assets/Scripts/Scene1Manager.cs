using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Scene2");
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Scene2()
    {
        yield return new WaitForSeconds(25);
        SceneManager.LoadScene(1);
    }
}
