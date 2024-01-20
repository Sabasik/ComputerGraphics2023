using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorLever : Holdable
{
    public bool isRed;
    public bool isGreen;
    public bool isBlue;
    private bool isMoving;

    public float movementAreaLength = 0.5f;
    private float maxPos;
    private float minPos;
    private float posDiff;

    private MirrorPanel mirrorPanel;
    public string mirrorPanelTag = "MirrorPanel";

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        mirrorPanel = GameObject.Find("MirrorLeverMechanism").GetComponent<MirrorPanel>();

        maxPos = transform.position.y;
        minPos = transform.position.y - movementAreaLength;
        posDiff = maxPos - minPos;
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
                if (hit.collider.CompareTag(mirrorPanelTag))
                {
                    transform.position = new Vector3(transform.position.x, Mathf.Clamp(hit.point.y, minPos, maxPos), transform.position.z);

                    float colourValue = (transform.position.y - minPos) / posDiff;
                    Debug.Log(colourValue);
                    if (isRed) mirrorPanel.UpdateRedMultiplier(colourValue);
                    if (isGreen) mirrorPanel.UpdateGreenMultiplier(colourValue);
                    if (isBlue) mirrorPanel.UpdateBlueMultiplier(colourValue);
                }
            }
        }
    }

    public override void StartHolding()
    {
        isMoving = true;
        
    }

    public override void StopHolding()
    {
        isMoving = false;
    }
}
