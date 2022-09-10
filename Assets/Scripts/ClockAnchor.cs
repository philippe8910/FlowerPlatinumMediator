using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnchor : Grabbable
{
    public Vector3 m_currentInputY , m_defaultInputY , m_inputDefault;
    
    
    public override void Grab()
    {
        base.Grab();
    }

    public override void Start()
    {
        m_defaultInputY = transform.position;
    }

    public override void Update()
    {
        base.Update();
        
        transform.LookAt(new Vector3(0,transform.position.y,0));
        
        //transform.forward = Vector3.zero;
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
        //transform.position = lerpVector;
        //transform.LookAt(new Vector3(transform.position.x , transform.position.y , m_currentInputY.z));;
    }

    public override void UnGrab()
    {
        base.UnGrab();
    }

    public override void SetLerpVector(Vector3 input, Quaternion inputRotate)
    {
        //transform.LookAt(new Vector3(input.x,transform.position.y,input.z));
        
    }

    public override void EnterGrab(Transform input)
    {
        m_inputDefault = input.transform.position;
    }
}
