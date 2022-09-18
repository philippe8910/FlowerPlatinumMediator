using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;

public class OnceBreakBridge : MonoBehaviour
{
    [SerializeField] private bool isEnter;

    [SerializeField] private bool isStop;
    void Start()
    {
        EventBus.Subscribe<StopTimeDetected>(OnStopTimeDetected);
    }

    private void OnStopTimeDetected(StopTimeDetected obj)
    {
        var _isStop = obj.isStop;
        
        isStop = _isStop;
    }

    private void Update()
    {
        if (isEnter)
        {
            if (!isStop)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isEnter = true;
        }
    }
}
