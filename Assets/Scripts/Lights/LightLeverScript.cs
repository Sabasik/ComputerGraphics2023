using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using static UnityEditor.PlayerSettings;

public class LightLeverScript : Interactable
{
    public LightController controller;
    public float movementAreaLength;
    public bool isRed = false;
    public bool isGreen = false;
    public bool isBlue = false;

    private bool isMoving;
    private float maxPos;
    private float minPos;
    private float posDiff;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        maxPos = transform.position.y;
        minPos = transform.position.y - movementAreaLength;
        posDiff = maxPos - minPos;

        if (isRed) controller.UpdateRedMultiplier(1);
        if (isGreen) controller.UpdateGreenMultiplier(1);
        if (isBlue) controller.UpdateBlueMultiplier(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, 5);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag("LightPanel"))
                {
                    transform.position = new Vector3(transform.position.x, Mathf.Clamp(hit.point.y, minPos, maxPos), transform.position.z);

                    float colourValue = (transform.position.y - minPos) / posDiff;
                    if (isRed) controller.UpdateRedMultiplier(colourValue);
                    if (isGreen) controller.UpdateGreenMultiplier(colourValue);
                    if (isBlue) controller.UpdateBlueMultiplier(colourValue);
                }
            }
        }

    }

    public override void StartInteract()
    {
        isMoving = true;

    }

    public override void StopInteract()
    {
        isMoving = false;
    }

}
