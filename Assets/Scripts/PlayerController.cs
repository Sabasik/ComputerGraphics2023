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
            if (hoveringInteractable != null)
            {
                hoveringInteractable.StartInteract();
                currentlyInteractingInteractable = hoveringInteractable;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (currentlyInteractingInteractable != null)
            {
                currentlyInteractingInteractable.StopInteract();
                currentlyInteractingInteractable = null;
            }
        }

        if (currentlyInteractingInteractable != null && currentlyInteractingInteractable.isHoldable)
        {
            currentlyInteractingInteractable.transform.position = ray.GetPoint(holdingDistance);
        }
    }
}
