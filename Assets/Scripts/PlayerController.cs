using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Interactable hoveringInteractable;
    private Interactable currentlyInteractingInteractable;

    public float holdingDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitPoint;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hitPoint, 100f))
        {
            hoveringInteractable = hitPoint.transform.gameObject.GetComponent<Interactable>();
            //Debug.Log(hoveringInteractable);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hoveringInteractable != null && currentlyInteractingInteractable == null)
            {
                hoveringInteractable.StartInteract();
                currentlyInteractingInteractable = hoveringInteractable;
            } else if (currentlyInteractingInteractable != null)
            {
                currentlyInteractingInteractable.StopInteract();
                currentlyInteractingInteractable = null;
            }
        }

        if (currentlyInteractingInteractable != null && currentlyInteractingInteractable.isHoldable)
        {
            currentlyInteractingInteractable.transform.position = ray.GetPoint(holdingDistance);

            Transform currentHoldableTransform = currentlyInteractingInteractable.transform;

            // Tilt
            if (Input.GetKey(KeyCode.Keypad7))
            {
                currentlyInteractingInteractable.Rotate(currentHoldableTransform.right, -1);
            }
            if (Input.GetKey(KeyCode.Keypad9))
            {
                currentlyInteractingInteractable.Rotate(currentHoldableTransform.right, 1);
            }

            // Left-Right
            if (Input.GetKey(KeyCode.Keypad4))
            {
                currentlyInteractingInteractable.Rotate(currentHoldableTransform.up, 1);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                currentlyInteractingInteractable.Rotate(currentHoldableTransform.up, -1);
            }

            // Roll
            if (Input.GetKey(KeyCode.Keypad5))
            {
                currentlyInteractingInteractable.Rotate(currentHoldableTransform.forward, -1);
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                currentlyInteractingInteractable.Rotate(currentHoldableTransform.forward, 1);
            }

        }
    }
}
