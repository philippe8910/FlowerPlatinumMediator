using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnchor : Grabbable
{
    public override void Grab()
    {
        base.Grab();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void DisGrab()
    {
        if (moveBack)
        {
            //transform.position = Vector3.Lerp(transform.position , defaultVector , 0.2f);
        }
    }

    public override void OnGrab()
    {
        transform.position = lerpVector;
    }

    public override void UnGrab()
    {
        base.UnGrab();
    }

    public override void SetLerpVector(Vector3 input)
    {
        lerpVector = input;
    }
}
