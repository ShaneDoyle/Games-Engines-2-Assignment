using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene10FlashEnd : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EndScene");
    }

    //Update is called once per frame
    void Update()
    {

    }

    IEnumerator EndScene()
    {

        yield return new WaitForSeconds(0.1f);
        StartCoroutine("CallFlash");
        SceneManager.LoadScene(11);

    }
}
