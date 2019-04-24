using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraApe : MonoBehaviour
{
    public GameObject FollowTarget;

    public GameObject FollowTargetTarget;

    public GameObject[] Group1Monkeys = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        Group1Monkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup1");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 XPOS = new Vector3(0, 0, 0);
        for (int i = 0; i < Group1Monkeys.Length; i++)
        {
            GameObject temp = Group1Monkeys[i];
            XPOS += temp.transform.position;
        }
        XPOS = XPOS / Group1Monkeys.Length;

        //MonkeyLeader enemy = FollowTarget.GetComponent<MonkeyLeader>();
        //FollowTargetTarget = enemy.target;
        //Vector3 Temp = new Vector3 (FollowTarget.transform.position.x, FollowTarget.transform.position.y + 3, FollowTarget.transform.position.z - 4);
        //transform.position = Temp;

        transform.LookAt(XPOS);
        */


        transform.position = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y + 3, FollowTarget.transform.position.z - 4);
        transform.rotation = Quaternion.Euler(20, FollowTarget.transform.rotation.y, 0); // this is 90 degrees around y axis
    }
}
