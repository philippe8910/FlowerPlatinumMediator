using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] public bool isGrab;

    [SerializeField] public bool moveBack;

    [SerializeField] [FoldoutGroup("LimitBox")] public bool limitVectorX, limitVectorY, limitVectorZ;

    [SerializeField] [FoldoutGroup("LimitPos")] public float limitPosX, limitPosY, limitPosZ;

    //[SerializeField] [FoldoutGroup("OffsetVector")] public Vector3 centerOffset;

    //[SerializeField] [FoldoutGroup("OffsetVector")] private Vector3 triggerValue;

    [SerializeField] public Vector3 lerpVector, defaultVector;

    private Rigidbody rigidbody;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        defaultVector = transform.position;
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isGrab)
        {
            OnGrab();
        }
        else
        {
            DisGrab();
        }
    }

    public virtual void OnGrab()
    {
        transform.position = Vector3.Lerp(transform.position , lerpVector , 0.02f);
        //rigidbody.MovePosition(Vector3.Lerp(transform.position, lerpVector, 0.02f));
    }

    public virtual void DisGrab()
    {
        if (moveBack)
        {
            transform.position = Vector3.Lerp(transform.position , defaultVector , 0.02f);
            //rigidbody.velocity = Vector3.Lerp(transform.position , defaultVector , 0.02f);
        }
    }

    public virtual void Grab()
    {
        isGrab = true;
    }

    public virtual void UnGrab()
    {
        isGrab = false;
    }

    public virtual void EnterGrab(Transform input)
    {
        
    }

    public virtual void SetLerpVector(Vector3 input , Quaternion inputRotate)
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

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireCube(transform.position + centerOffset , triggerValue);
    }
}
