using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : TriggerWall
{
    [SerializeField] private Quaternion defaultPos;

    [SerializeField] private Vector3 targetPos;

    private void Start()
    {
        defaultPos = transform.rotation;
    }

    public override void OnTriggerEnter()
    {
        base.OnTriggerEnter();
    }

    public override void OnTriggerExit()
    {
        isEnter = false;
        timer = 0;
    }

    public override void OnTriggerStayFalse()
    {
        if (isEnter)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation , defaultPos , 0.1f);
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= 2)
            {
                isEnter = true;
            }
        }
    }

    public override void OnTriggerStayTrue()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(targetPos) , 0.1f);
        timer = 0;
    }
}
