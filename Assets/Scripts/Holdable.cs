using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    protected Rigidbody rigidBody;

    public bool freelyMovable = false;
    public float rotatingSpeed = 1;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public virtual void StartHolding()
    {
        if (freelyMovable)
        {
            rigidBody.useGravity = false;
        }
    }

    public virtual void StopHolding()
    {
        if (freelyMovable)
        {
            rigidBody.useGravity = true;
        }
    }

    public void Rotate(Vector3 rotationAxis, int modifier)
    {
        transform.RotateAround(transform.position, rotationAxis, Time.deltaTime * modifier * rotatingSpeed * 90f);
    }
}
