using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxController : Interactable
{
    public Material colorChecked;
    public Material colorNotChecked;
    private bool isMoving;
    private bool isChecked;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        isChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            isMoving = true;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, 5);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.name == this.gameObject.name)
                {
                    if (!isChecked){
                        transform.position = new Vector3(transform.position.x - 0.075f, transform.position.y, transform.position.z);
                        this.GetComponent<Renderer>().material = colorChecked;
                        isChecked = true;
                    } else {
                        transform.position = new Vector3(transform.position.x + 0.075f, transform.position.y, transform.position.z);
                        this.GetComponent<Renderer>().material = colorNotChecked;
                        isChecked = false;
                    }
                    break;
                }
            }
            
            isMoving = false;
        }
    }
}
