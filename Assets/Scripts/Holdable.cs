using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    protected Rigidbody rigidBody;

    public bool freelyMovable = false;
    public float movingSpeed = 10f;
    public float rotatingSpeed = 1f;

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

    public void MoveTowards(Vector3 point)
    {
        rigidBody.velocity = (point - transform.position) * movingSpeed;
    }

    public void Rotate(Vector3 rotationAxis, int modifier)
    {
        transform.RotateAround(transform.position, rotationAxis, Time.deltaTime * modifier * rotatingSpeed * 90f);
    }
}
