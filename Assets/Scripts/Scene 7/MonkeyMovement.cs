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
