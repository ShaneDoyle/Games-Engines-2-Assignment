using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject[] EnemyMonkeys = new GameObject[4];
    public int counter = 0;

    // Update is called once per frame
    void Update()
    {
        //Check if enemy monkeys are dead.
        EnemyMonkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup2");
        for(int i = 0; i<EnemyMonkeys.Length; i++)
        {
            GameObject temp = EnemyMonkeys[i];
            MonkeyLeader Monkey = temp.GetComponent<MonkeyLeader>();
            if (Monkey.HP <= 0)
            {
                counter++;
            }
        }
        if(counter >= 3)
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
}
