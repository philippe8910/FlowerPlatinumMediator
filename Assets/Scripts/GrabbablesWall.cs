using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GrabbablesWall : MonoBehaviour , IGrabbable
{
    [SerializeField] private bool isGrab;

    [SerializeField] private bool moveBack;

    [SerializeField] [FoldoutGroup("LimitBox")] private bool limitVectorX, limitVectorY, limitVectorZ;

    [SerializeField] [FoldoutGroup("LimitPos")] private float limitPosX, limitPosY, limitPosZ;

    [SerializeField] private Vector3 lerpVector, defaultVector;

    private void Start()
    {
        defaultVector = transform.position;
    }

    private void Update()
    {
        if (isGrab)
        {
            OnGrab(this);
        }
        else
        {
            DisGrab(this);
        }
    }

    public void Grab(object action)
    {
        isGrab = true;
    }

    public void UnGrab(object action)
    {
        isGrab = false;
    }

    public void OnGrab(object action)
    {
        transform.position = Vector3.Lerp(transform.position , lerpVector , 0.02f);
    }

    public void DisGrab(object action)
    {
        if (moveBack)
        {
            transform.position = Vector3.Lerp(transform.position , defaultVector , 0.02f);
        }
    }
    
    public void SetLerpVector(Vector3 input)
    {
        float inputX = input.x;
        float inputY = input.y;
        float inputZ = input.z;
        
        if (limitVectorX) inputX = transform.position.x;
        if (limitVectorY) inputY = transform.position.y;
        if (limitVectorZ) inputZ = transform.position.z;
        
        if(defaultVector.x < limitPosX) inputX = Mathf.Clamp(inputX, defaultVector.x, limitPosX);
        if(defaultVector.y < limitPosY) inputY = Mathf.Clamp(inputY, defaultVector.y, limitPosY);       
        if(defaultVector.z < limitPosZ) inputZ = Mathf.Clamp(inputZ, defaultVector.z, limitPosZ);
        
        if(defaultVector.x > limitPosX) inputX = Mathf.Clamp(inputX,limitPosX ,  defaultVector.x);
        if(defaultVector.y > limitPosY) inputY = Mathf.Clamp(inputY,limitPosY ,  defaultVector.y);       
        if(defaultVector.z > limitPosZ) inputZ = Mathf.Clamp(inputZ,limitPosZ ,  defaultVector.z);

        lerpVector = new Vector3(inputX, inputY, inputZ);

    }
}
