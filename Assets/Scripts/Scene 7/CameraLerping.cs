using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerping : MonoBehaviour
{
    public GameObject FollowTarget;
   // public GameObject FollowTargetTarget;
    public GameObject LookFollowTarget;
    public GameObject[] Group1Monkeys = new GameObject[50];

    //Start is called before the first frame update
    void Start()
    {
        Group1Monkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup1");
    }

    //Update is called once per frame
    void Update()
    {

        //Get Average location of the main monkeys.
        Vector3 XPOS = new Vector3(0, 0, 0);
        for (int i = 0; i < Group1Monkeys.Length; i++)
        {
            GameObject temp = Group1Monkeys[i];
            XPOS += temp.transform.position;
        }
        XPOS = XPOS / Group1Monkeys.Length;

        //transform.position = Vector3.Lerp(transform.position, FollowTarget.transform.position, 0.02f);
        Vector3 CameraPos = new Vector3(XPOS.x, XPOS.y + 6, XPOS.z - 10);
        transform.position = Vector3.Lerp(transform.position, CameraPos, 0.1f);


        //Vector3 targetPosition = new Vector3(LookFollowTarget.transform.position.x, transform.position.y, LookFollowTarget.transform.position.z);
        Vector3 targetPosition = new Vector3(XPOS.x, transform.position.y, XPOS.z);
        Vector3 pos = LookFollowTarget.transform.position - transform.position;
        Quaternion newRot = Quaternion.LookRotation(pos);

       // transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 0.1f);
    }
}


