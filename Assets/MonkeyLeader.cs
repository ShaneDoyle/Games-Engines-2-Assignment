using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyLeader : MonoBehaviour
{
    private Animator myAnimator;
    public string State = "Pursue";
    public GameObject target;
    public GameObject attackhitbox;
    public GameObject[] EnemyMonkeys = new GameObject[4];
    public int HP = 5;

    //Built in
    public float ApeSpeed;
    private bool StateChange = true;
    private float FleeRange = 10f;
    private bool StrafeChange = true;
    private bool ApeSpeedReset = true;

    IEnumerator NewState()
    {
        ApeSpeed = Random.Range(0.6f, 1.2f);
        yield return new WaitForSeconds(0.75f);
        myAnimator.SetInteger("CurrentAction", 0);
        StateChange = true;
        State = "Flee";
        FleeRange = Random.Range(7f, 10f);
    }

    IEnumerator StopFlee()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        ChooseTarget();
        myAnimator.SetInteger("CurrentAction", 0);
        StateChange = true;
        State = "Pursue";
    }

    IEnumerator Strafing()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
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
                enemy.HP -= 1;
            }
        }
    }

    //Used on Death
    IEnumerator StopAnimationSpeed()
    {
        yield return new WaitForSeconds(6f);
        ApeSpeed = 0f;
    }

    void ChooseTarget()
    {
        //Clear Target.
        target = null;
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
                ApeSpeed = 1.0f;
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
                transform.LookAt(targetPosition);
            }
        }

        //Make idle if no target.
        if(target == null)
        {
            State = "Idle";
        }


        //Affect animator to increase ape speed.
        myAnimator.speed = ApeSpeed;



        //Monkey Behaviours!
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

        //Monkey Behaviours!
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
                //ApeSpeed = Random.Range(0.6f, 1.2f);
                StartCoroutine("InflictDamage");
                StateChange = false;
                StartCoroutine("NewState");
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





        if (Input.GetKey("a") && (myAnimator.GetInteger("CurrentAction") == 0))
        {

            transform.Rotate(Vector3.down * Time.deltaTime * 180.0f);

            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningLeft", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningLeft", false);
        }

        //Same thing for E key, just rotating the other way!
        if (Input.GetKey("d") && (myAnimator.GetInteger("CurrentAction") == 0))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 180.0f);
            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningRight", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningRight", false);
        }


        if (Input.GetKeyDown("4"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 4);
        }

        if (Input.GetKeyUp("4"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }

        if (Input.GetKeyDown("5"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 5);
        }

        if (Input.GetKeyUp("5"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }

        /*
        if (Input.GetKeyDown("6"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 6);
        }

        if (Input.GetKeyUp("6"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }

        //myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
       // myAnimator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));
       */

    }
}
        /*
        if (Input.GetButtonDown("Jump"))
        {
            myAnimator.SetBool("Jumping", true);
            Invoke("StopJumping", 0.1f);
        }


        if (Input.GetKey("a") && (myAnimator.GetInteger("CurrentAction") == 0))
        {

            transform.Rotate(Vector3.down * Time.deltaTime * 180.0f);

            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningLeft", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningLeft", false);
        }

        //Same thing for E key, just rotating the other way!
        if (Input.GetKey("d") && (myAnimator.GetInteger("CurrentAction") == 0))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 180.0f);
            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningRight", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningRight", false);
        }
    }
}


        /*
        if (Input.GetKeyDown("1"))
        {
            if (myAnimator.GetInteger("CurrentAction") == 0)
            {
                myAnimator.SetInteger("CurrentAction", 1);
            }
            else if (myAnimator.GetInteger("CurrentAction") == 1)
            {
                myAnimator.SetInteger("CurrentAction", 0);
            }
        }


        if (Input.GetKeyDown("2"))
        {
            if (myAnimator.GetInteger("CurrentAction") == 0)
            {
                myAnimator.SetInteger("CurrentAction", 2);
            }
            else if (myAnimator.GetInteger("CurrentAction") == 2)
            {
                myAnimator.SetInteger("CurrentAction", 0);
            }
        }

        if (Input.GetKeyDown("3"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 3);
        }

        if (Input.GetKeyUp("3"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }


        if (Input.GetKeyDown("4"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 4);
        }

        if (Input.GetKeyUp("4"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }

        if (Input.GetKeyDown("5"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 5);
        }

        if (Input.GetKeyUp("5"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }

        if (Input.GetKeyDown("6"))
        {
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 6);
        }

        if (Input.GetKeyUp("6"))
        {
            myAnimator.SetInteger("CurrentAction", 0);
        }

    }

    void StopJumping()
    {
        myAnimator.SetBool("Jumping", false);
    }
    */
