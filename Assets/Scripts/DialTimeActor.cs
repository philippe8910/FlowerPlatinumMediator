using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;

public class DialTimeActor : MonoBehaviour
{
    private Transform dialTransform;

    private bool isTrigger;
    
    void Start()
    {
        dialTransform.GetChild(0);
        
        EventBus.Subscribe<TimeFissureTriggerDetected>(OnTimeFissureTriggerDetected);
    }

    private void OnTimeFissureTriggerDetected(TimeFissureTriggerDetected obj)
    {
        isTrigger = obj.isTrigger;

        dialTransform.gameObject.SetActive(isTrigger);
    }
}
