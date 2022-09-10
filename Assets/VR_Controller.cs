using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Valve.VR;

public class VR_Controller : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Boolean grabAction;

    [SerializeField] private SteamVR_Input_Sources inputSource;

    [SerializeField] private float  grabAreaRange;

    [SerializeField] private Vector3 grabOffset;

    [SerializeField] private LayerMask grabbableObejctLayerMask;

    private bool isGrab;

    private Grabbable targetGrabbable;

    private Vector3 grabObjectVector3;

    private LineRenderer grabLineRenderer;

    private TrailRenderer grabTrailRenderer;

    private MeshRenderer meshRenderer;

    protected Material unTriggerMaterial, triggerMaterial;
    

    private void Start()
    {
        unTriggerMaterial = Resources.Load<Material>("GrabMaterial/UnTriggerMaterial");
        triggerMaterial = Resources.Load<Material>("GrabMaterial/TriggerMaterial");
        meshRenderer = GetComponent<MeshRenderer>();

        grabLineRenderer = transform.GetChild(0).GetComponent<LineRenderer>();
        grabTrailRenderer = transform.GetChild(0).GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position + grabOffset , grabAreaRange , grabbableObejctLayerMask))
        {
            SetMeshRenderMaterial(triggerMaterial);

            if (grabAction[inputSource].stateDown)
            {
                isGrab = true;
                grabObjectVector3 = GetGrabObjectTransform().position;
                grabTrailRenderer.enabled = false;

                targetGrabbable = GetGrabObjectTransform().GetComponent<Grabbable>();
                targetGrabbable.EnterGrab(transform);
                Debug.Log(targetGrabbable);
            }
        }
        else
        {
            SetMeshRenderMaterial(unTriggerMaterial);
        }
        
        if (grabAction[inputSource].stateUp)
        {
            isGrab = false;
            grabObjectVector3 = Vector3.zero;
            grabTrailRenderer.enabled = true;
        }

        Grabbing();
    }

    private void Grabbing()
    {
        if (isGrab)
        {
            SetGrabLineRender(transform.position , targetGrabbable.transform.position);
            
            targetGrabbable.Grab();
            targetGrabbable.SetLerpVector(transform.position , transform.rotation);
        }
        else
        {
            SetGrabLineRender(grabObjectVector3 , grabObjectVector3);
            
            targetGrabbable?.UnGrab();
        }
    }

    private Transform GetGrabObjectTransform()
    {
        return Physics.OverlapSphere(transform.position + grabOffset , grabAreaRange , grabbableObejctLayerMask)[0].transform;
    }

    private void SetGrabLineRender(Vector3 start , Vector3 end)
    {
        grabLineRenderer.SetPosition(0 , start);
        grabLineRenderer.SetPosition(1 , end);
    }

    private void SetMeshRenderMaterial(Material material)
    {
        meshRenderer.material = material;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + grabOffset , grabAreaRange);
    }
}
