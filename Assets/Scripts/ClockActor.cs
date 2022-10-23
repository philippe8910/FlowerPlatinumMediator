using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;

public class ClockActor : MonoBehaviour
{
    private RepairArea repairArea;

    private bool isGrab;

    [SerializeField] private Quaternion currentQuaternion , defaultQuaternion;

    private void Start()
    {
        EventBus.Subscribe<EnterRepairAreaDetected>(OnEnterRepairAreaDetected);
    }

    private void OnEnterRepairAreaDetected(EnterRepairAreaDetected obj)
    {
        var input = obj.repairArea;

        repairArea = input;
    }

    private void Update()
    {
        if (repairArea != null && isGrab)
        {
            var dis = (Quaternion.Angle(transform.rotation, defaultQuaternion) / 180f);
            
            if(!repairArea.GetIsStop()) repairArea.SetTime(dis);

            Debug.Log("Repairing");
        }
    }

    public void OnAttachedToHand()
    {
        defaultQuaternion = transform.rotation;
        repairArea?.OnAttachedToHand();
        isGrab = true;
        //Debug.Log("Attached Point!!!");

    }
    
    public void OnDetachedToHand()
    {
        defaultQuaternion = transform.rotation;
        repairArea?.OnDetachedToHand();
        isGrab = false;
        //Debug.Log("Detached Point!!!");
    }
    
    
    
}
