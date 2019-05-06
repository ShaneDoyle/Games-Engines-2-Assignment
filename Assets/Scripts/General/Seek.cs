using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    //Public variables.
    public float MaxVelocity = 3;
    public Transform target;

    //Private variables.
    private float Mass = 15;
    private float MaxForce = 15;
    private Vector3 velocity;

    //Start is called before the first frame update.
    private void Start()
    {
        velocity = Vector3.zero;
    }

    //Update is called once per frame.
    private void Update()
    {
        var desiredVelocity = target.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
    }
}
