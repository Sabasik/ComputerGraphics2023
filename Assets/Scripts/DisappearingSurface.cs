using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingSurface : Activatable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        base.Activate();
        GameObject.Destroy(gameObject);
    }
}
