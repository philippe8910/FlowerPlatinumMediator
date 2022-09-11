using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class RepairArea : MonoBehaviour
{
    [SerializeField] public Animation animation;

    [SerializeField] private string animationName;

    [SerializeField] private float animationTime;

    private void Start()
    {
        
    }

    private void Update()
    {
        animation[animationName].time = animationTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Post(new EnterRepairAreaDetected(this , animationName));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Post(new EnterRepairAreaDetected(null , null));
            animationTime = 0;
        }
    }

    public void SetTime(float value)
    {
        animationTime = value;
    }
}
