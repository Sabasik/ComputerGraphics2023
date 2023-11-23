using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorLever : Interactable
{
    public bool isRed;
    public bool isGreen;
    public bool isBlue;

    private MirrorPanel mirrorPanel;

    // Start is called before the first frame update
    void Start()
    {
        mirrorPanel = GameObject.Find("MirrorPanel").GetComponent<MirrorPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StartInteract()
    {
        if (isRed) mirrorPanel.UpdateRedMultiplier(Random.value);
        if (isGreen) mirrorPanel.UpdateGreenMultiplier(Random.value);
        if (isBlue) mirrorPanel.UpdateBlueMultiplier(Random.value);
    }
}
