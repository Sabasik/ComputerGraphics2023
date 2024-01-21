using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckBoxController : Holdable
{
    private bool isMoving;
    private bool isChecked;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        isMoving = false;
        isChecked = false;
        this.GetComponent<Renderer>().material.DOColor(Color.red, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && !isMoving)
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
                        transform.DOMoveX(transform.position.x - 0.075f, 1);
                        this.GetComponent<Renderer>().material.DOColor(Color.yellow, 1);
                        isChecked = true;
                        CheckCombination.checkCombination.doCheck();
                    } else {
                        transform.DOMoveX(transform.position.x + 0.075f, 1);
                        this.GetComponent<Renderer>().material.DOColor(Color.red, 1);
                        isChecked = false;
                        CheckCombination.checkCombination.doCheck();
                    }
                    break;
                }
            }
            
            isMoving = false;
        }
    }

    public bool getCheck() {
        return isChecked;
    }
}
