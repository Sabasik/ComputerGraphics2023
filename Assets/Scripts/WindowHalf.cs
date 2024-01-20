using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHalf : Interactable
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(PlayerController player)
    {
        rigidbody.AddForce(player.transform.position - transform.position, ForceMode.Impulse);
    }
}
