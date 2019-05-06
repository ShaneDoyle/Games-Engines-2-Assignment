using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene12StarChild : MonoBehaviour
{
    //Public variables.
    public GameObject FadeOut;

    //Private variables.
    private float zaxis = 20;

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartFadeOut");
    }

    //Update is called once per frame
    void Update()
    {
        //Rotate star child.
        zaxis -= 0.02f;
        transform.eulerAngles = new Vector3(90, 180, zaxis);
    }

    //Enumerator to call flash out to end scene.
    IEnumerator StartFadeOut()
    {
        yield return new WaitForSeconds(17f);
        FadeOut.SetActive(true);
    }
}
