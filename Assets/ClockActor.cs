using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;

public class ClockActor : MonoBehaviour
{
    private RepairArea repairArea;

    private string stateName;

    [SerializeField] private Quaternion currentQuaternion , defaultQuaternion;

    private void Start()
    {
        EventBus.Subscribe<EnterRepairAreaDetected>(OnEnterRepairAreaDetected);
    }

    private void OnEnterRepairAreaDetected(EnterRepairAreaDetected obj)
    {
        var input = obj.repairArea;

        repairArea = input;
        stateName = obj.stateName;
    }

    private void Update()
    {
        if (repairArea != null)
        {
            var dis = (Quaternion.Angle(transform.rotation, defaultQuaternion) / 180f);
            repairArea.SetTime(dis);
        }
    }

    public void OnAttachedToHand()
    {
        defaultQuaternion = transform.rotation;
        //Debug.Log("Attached Point!!!");

    }
    
    public void OnDetachedToHand()
    {
        defaultQuaternion = transform.rotation;
        //Debug.Log("Detached Point!!!");
    }
    
    
    
}
