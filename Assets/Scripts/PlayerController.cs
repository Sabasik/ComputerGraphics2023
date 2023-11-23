using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Interactable hoveringInteractable;

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
            Debug.Log(hoveringInteractable);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hoveringInteractable != null)
            {
                hoveringInteractable.StartInteract();
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (hoveringInteractable != null)
            {
                hoveringInteractable.EndInteract();
            }
        }
    }
}
