using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyLeader : MonoBehaviour
{
    private Animator myAnimator;
    public string State = "Pursue";
    public GameObject target;

    //Built in
    public float ApeSpeed;
    private bool StateChange = true;

    IEnumerator NewState()
    {
        yield return new WaitForSeconds(0.75f);
        myAnimator.SetInteger("CurrentAction", 0);
        StateChange = true;
        State = "Flee";
    }

    // The start method is called when the script is initalized, before other stuff in the scripts start happening.
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        ApeSpeed = myAnimator.speed;
    }

    void Update()
    {
        //Affect animator to increase ape speed.
        myAnimator.speed = ApeSpeed;

        //Look at the target. Visual.
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.LookAt(targetPosition);
        }

        //Monkey Behaviours!
        if (State == "Pursue")
        {
            myAnimator.SetFloat("VSpeed", 1);
            myAnimator.SetFloat("HSpeed", 1);
            myAnimator.SetBool("TurningRight", false);
            myAnimator.SetBool("TurningLeft", false);
            ApeSpeed = 1.25f;

            if (Vector3.Distance(target.transform.position, transform.position) < 2)
            {
                State = "Attack";
            }
        }
        else if (State == "Attack")
        {
            ApeSpeed = 1f;
            myAnimator.SetFloat("VSpeed", 0);
            myAnimator.SetFloat("HSpeed", 0);
            myAnimator.SetLayerWeight(1, 1f);
            myAnimator.SetInteger("CurrentAction", 4);
            if (StateChange == true)
            {
                StateChange = false;
                StartCoroutine("NewState");
            }
        }
        else if (State == "Flee")
        {
            myAnimator.SetFloat("VSpeed", -1);
            myAnimator.SetFloat("HSpeed", -1);
            ApeSpeed = 0.75f;
            if (Vector3.Distance(target.transform.position, transform.position) > 9)
            {
                State = "Pursue";
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
        myAnimator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));

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
