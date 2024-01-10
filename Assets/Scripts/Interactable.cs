using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected Rigidbody rigidBody;

    public bool isHoldable = false;
    public float rotatingSpeed = 1;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public virtual void StartInteract()
    {
        if (isHoldable)
        {
            rigidBody.useGravity = false;
        }
    }

    public virtual void StopInteract()
    {
        if (isHoldable)
        {
            rigidBody.useGravity = true;
        }
    }

    public void Rotate(Vector3 rotationAxis, int modifier)
    {
        transform.RotateAround(transform.position, rotationAxis, Time.deltaTime * modifier * rotatingSpeed * 90f);
    }
}
