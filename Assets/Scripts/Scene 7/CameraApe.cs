using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraApe : MonoBehaviour
{
    //Public variables.
    public GameObject FollowTarget;
    public GameObject FollowTargetTarget;
    public GameObject[] Group1Monkeys = new GameObject[5];

    //Start is called before the first frame update.
    void Start()
    {
        Group1Monkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup1");
    }

    //Update is called once per frame.
    void Update()
    {
        Vector3 XPOS = new Vector3(0, 0, 0);
        for (int i = 0; i < Group1Monkeys.Length; i++)
        {
            GameObject temp = Group1Monkeys[i];
            XPOS += temp.transform.position;
        }
        XPOS = XPOS / Group1Monkeys.Length;
        transform.LookAt(XPOS);
    }
}
