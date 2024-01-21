using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Holdable hoveringHoldable;
    private Holdable currentlyHoldingHoldable;

    private Interactable hoveringInteractable;

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
            hoveringHoldable = hitPoint.collider.gameObject.GetComponent<Holdable>();
            hoveringInteractable = hitPoint.collider.gameObject.GetComponent<Interactable>();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hoveringHoldable != null && currentlyHoldingHoldable == null)
            {
                hoveringHoldable.StartHolding();
                currentlyHoldingHoldable = hoveringHoldable;
            } else if (currentlyHoldingHoldable != null)
            {
                currentlyHoldingHoldable.StopHolding();
                currentlyHoldingHoldable = null;
            }

            if (hoveringInteractable != null)
            {
                hoveringInteractable.Interact(this);
                Debug.Log("Interacting with " + hoveringInteractable.name);
            }
        }

        if (currentlyHoldingHoldable != null && currentlyHoldingHoldable.freelyMovable)
        {
            currentlyHoldingHoldable.transform.position = ray.GetPoint(holdingDistance);

            Transform currentHoldableTransform = currentlyHoldingHoldable.transform;

            // Tilt
            if (Input.GetKey(KeyCode.Keypad7))
            {
                currentlyHoldingHoldable.Rotate(currentHoldableTransform.right, -1);
            }
            if (Input.GetKey(KeyCode.Keypad9))
            {
                currentlyHoldingHoldable.Rotate(currentHoldableTransform.right, 1);
            }

            // Left-Right
            if (Input.GetKey(KeyCode.Keypad4))
            {
                currentlyHoldingHoldable.Rotate(currentHoldableTransform.up, 1);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                currentlyHoldingHoldable.Rotate(currentHoldableTransform.up, -1);
            }

            // Roll
            if (Input.GetKey(KeyCode.Keypad5))
            {
                currentlyHoldingHoldable.Rotate(currentHoldableTransform.forward, -1);
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                currentlyHoldingHoldable.Rotate(currentHoldableTransform.forward, 1);
            }

        }
    }
}
