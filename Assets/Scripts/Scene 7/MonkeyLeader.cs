using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyLeader : MonoBehaviour
{
    //Public variables.
    public string State = "Pursue";
    public GameObject target;
    public GameObject attackhitbox;
    public GameObject[] EnemyMonkeys = new GameObject[4];
    public GameObject Monolith;
    public int HP = 5;
    public float ApeSpeed;

    //Private variables.
    private Animator myAnimator;
    private bool StateChange = true;
    private float FleeRange = 10f;
    private bool StrafeChange = true;
    private bool ApeSpeedReset = true;

    //
    IEnumerator Flee()
    {
        ApeSpeed = Random.Range(0.6f, 1.2f);
        yield return new WaitForSeconds(0.75f);
        myAnimator.SetInteger("CurrentAction", 0);
        StateChange = true;
        State = "Flee";
        FleeRange = Random.Range(7f, 10f);
    }

    //Stop fleeing.
    IEnumerator StopFlee()
    {
        yield return new WaitForSeconds(Random.Range(1.25f, 2f));
        ChooseTarget();
        myAnimator.SetInteger("CurrentAction", 0);
        StateChange = true;
        State = "Pursue";
    }

    //Strafe.
    IEnumerator Strafing()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        myAnimator.SetFloat("HSpeed", Random.Range(-1f, 1f));
        yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
        myAnimator.SetFloat("HSpeed", 0);
        yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
        StrafeChange = true;
    }

    IEnumerator InflictDamage()
    {
        yield return new WaitForSeconds(ApeSpeed/2f);

        //Do damage.
        if (Vector3.Distance(target.transform.position, transform.position) < 1.75f)
        {
            if (State == "Attack" && HP >= 0)
            {
                MonkeyLeader enemy = target.GetComponent<MonkeyLeader>();
                if (target == Monolith)
                {

                }
                else
                {
                    enemy.HP -= 1;
                }
            }
        }
    }

    //Used on Death.
    IEnumerator StopAnimationSpeed()
    {
        ApeSpeed = 1.2f;
        yield return new WaitForSeconds(6f);
        ApeSpeed = 0f;
    }

    void ChooseTarget()
    {
        //Clear Target.
        EnemyMonkeys = new GameObject[4];
        if (tag == "MonkeyGroup1")
        {
            EnemyMonkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup2");
        }
        else
        {
            EnemyMonkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup1");
        }

        //Pick a monkey to target.
        if (EnemyMonkeys.Length > 0)
        {
            int temp = Random.Range(0, EnemyMonkeys.Length);
            target = EnemyMonkeys[temp];
        }
        else
        {
            //Do nothing.
        }
    }

    //Start variables.
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        ApeSpeed = myAnimator.speed;
        if (tag == "MonkeyGroup1")
        {
            EnemyMonkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup2");
        }
        else
        {
            EnemyMonkeys = GameObject.FindGameObjectsWithTag("MonkeyGroup1");
        }

        ChooseTarget();
    }

    //Behaviour managing.
    void Update()
    {
        //Death manager.
        if (HP <= 0)
        {
            State = "Dead";
            gameObject.tag = "Untagged";
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 0);
            myAnimator.SetFloat("VSpeed", 0);
            myAnimator.SetFloat("HSpeed", 0);
            myAnimator.SetBool("TurningRight", false);
            myAnimator.SetBool("TurningLeft", false);

            //Reset Ape Speed on Death.
            if (ApeSpeedReset == true)
            {
                StartCoroutine("StopAnimationSpeed");
                ApeSpeedReset = false;
            }
        }
        else
        { 
            //Cause casual strafing.
            if (StrafeChange == true)
            {
                if (target != null)
                {
                    StrafeChange = false;
                    StartCoroutine("Strafing");
                }
            }

            //Look at the target. Visual.
            if (target != null)
            {
                Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                Vector3 pos = target.transform.position - transform.position;
                Quaternion newRot = Quaternion.LookRotation(pos);
               
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 0.1f);
            }
        }

        //Make idle if no target.
        if(target == null)
        {
            State = "Idle";
        }

        //Affect animator to increase ape speed.
        myAnimator.speed = ApeSpeed;

        //Monkey Behaviour States!
        if (State == "Dead")
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 6);
        }
        else if(State == "Idle")
        {
            myAnimator.SetFloat("VSpeed", 0);
            myAnimator.SetFloat("HSpeed", 0);
            ApeSpeed = 0.5f;
        }

        else if (State == "Pursue")
        {
            myAnimator.SetFloat("VSpeed", 1);
            myAnimator.SetBool("TurningRight", false);
            myAnimator.SetBool("TurningLeft", false);
            ApeSpeed = Mathf.Lerp(ApeSpeed, 1.0f, 0.005f);

            if (Vector3.Distance(target.transform.position, transform.position) < 1.0f)
            {
                State = "Attack";
            }
        }
        else if (State == "Attack")
        {
            myAnimator.SetFloat("VSpeed", 0);
            myAnimator.SetFloat("HSpeed", 0);
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 4);
            if (StateChange == true)
            {
                StartCoroutine("InflictDamage");
                StateChange = false;
                StartCoroutine("Flee");
            }
        }
        else if (State == "Flee")
        {
            myAnimator.SetFloat("VSpeed", -1);
            ApeSpeed = Mathf.Lerp(ApeSpeed, 0.7f, 0.01f);
            if (StateChange == true)
            {
                StateChange = false;
                StartCoroutine("StopFlee");
            }
        }
        else
        {
            myAnimator.SetBool("TurningLeft", false);
            myAnimator.SetBool("TurningRight", false);
        }
    }
}