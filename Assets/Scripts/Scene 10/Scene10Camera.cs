using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene10Camera : MonoBehaviour
{
    public GameObject[] Screaming;
    public int ScreamIndex = 0;

    public float zRotate = 0;
    private float zRotation = 0;
    private bool NextScream = true;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        zRotation += zRotate;
        transform.eulerAngles = new Vector3(0, 0, zRotation);

        if(NextScream == true)
        {
            NextScream = false;
            StartCoroutine("MoveScream");
        }

    }

    IEnumerator MoveScream()
    {
        yield return new WaitForSeconds(5);
        Screaming[ScreamIndex].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Screaming[ScreamIndex].SetActive(false);
        NextScream = true;
        ScreamIndex++;
        //Do damage.
    }

}
