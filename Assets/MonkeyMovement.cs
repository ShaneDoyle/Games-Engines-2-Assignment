using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    private Animator myAnimator;
    public float ApeSpeed = 0;

    //Start is called before the first frame update.
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        ApeSpeed = myAnimator.speed;
        myAnimator.speed = Random.Range(1f, 1.5f);
    }

    //Update is called once per frame. 
    void Update()
    {

        myAnimator.SetFloat("VSpeed", 1); //Input.GetAxis("Vertical"));
        myAnimator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));

        //Turn left.
        if (Input.GetKey("a") && (myAnimator.GetInteger("CurrentAction") == 0))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 150.0f);

            //Also, IF we're currently standing still (both vertically and horizontally)
            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                myAnimator.SetBool("TurningLeft", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningLeft", false);
        }


        //Turn right.
        if (Input.GetKey("d") && (myAnimator.GetInteger("CurrentAction") == 0))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 150.0f);
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
        //Set Jump Boolean to true to trigger jump animation, then wait a small time and set to false so we don't jump agani.
        if (Input.GetButtonDown("Jump"))
        {
            myAnimator.SetBool("Jumping", true);
            Invoke("StopJumping", 0.1f);
        }


        
        if (Input.GetKey("q") && (myAnimator.GetInteger("CurrentAction") == 0))
        {
            //Rotate the character procedurally based on Time.deltaTime.  This will give the illusion of moving
            transform.Rotate(Vector3.down * Time.deltaTime * 100.0f);

            //Also, IF we're currently standing still (both vertically and horizontally)
            if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0))
            {
                //change the animation to the 'inplace' animation
                myAnimator.SetBool("TurningLeft", true);
            }

        }
        else
        {
            myAnimator.SetBool("TurningLeft", false);
        }
        */



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
    
}
*/
