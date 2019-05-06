using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene10EyeVideo : MonoBehaviour
{
    //Public Variables.
    public GameObject FlashCall;

    //Start is called before the first frame update.
    void Start()
    {
        StartCoroutine("CallFlash");
    }

    //Update is called once per frame.
    void Update()
    {
        
    }

    //Enumerator to call flash out to end scene.
    IEnumerator CallFlash()
    {

        yield return new WaitForSeconds(19f);
        FlashCall.SetActive(true);
        Destroy(this.gameObject);
    }
}
