﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject[] EnemyMonkeys = new GameObject[4];
    public GameObject SceneManager;
    public AudioSource Apes;
    public AudioSource Music;
    public int counter = 0;

    private bool MonkeysKilled = false;
    private bool FadeMusic = false;

    private void Start()
    {
        EnemyMonkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup2");
    }

    // Update is called once per frame
    void Update()
    {
        //Check if enemy monkeys are dead.
        for(int i = 0; i<EnemyMonkeys.Length; i++)
        {
            GameObject temp = EnemyMonkeys[i];
            MonkeyLeader Monkey = temp.GetComponent<MonkeyLeader>();
            if (Monkey.HP <= 0)
            {
                counter++;
            }
        }
        if(counter >= EnemyMonkeys.Length)
        {
            if (MonkeysKilled == false)
            {
                MonkeysKilled = true;
                StartCoroutine("MonkeysDefeated");
            }
        }
        else
        {
            counter = 0;
        }

        if(FadeMusic == true)
        {
            Apes.volume -= 0.002f;
            Music.volume -= 0.002f;
        }
    }

    
    IEnumerator MonkeysDefeated()
    {
        
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(4f);
        FadeMusic = true;
        SceneManager.SetActive(true);
    }
}
