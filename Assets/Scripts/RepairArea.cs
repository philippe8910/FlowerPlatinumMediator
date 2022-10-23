using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class RepairArea : MonoBehaviour
{
    [SerializeField] public Animation animation;

    [SerializeField] private string animationName;

    [SerializeField] private float animationTime;

    [SerializeField] private bool isEnterArea , isAttached , isStop;

    private void Start()
    {
        EventBus.Subscribe<StopTimeDetected>(OnStopTimeDetected);
    }

    private void OnStopTimeDetected(StopTimeDetected obj)
    {
        isStop = obj.isStop;
    }

    private void Update()
    {
        if (isStop)
        {
            animation[animationName].time = animationTime;
        }
        else
        {
            if (isEnterArea)   //進入區域
            {
                if (isAttached) //抓取時
                {
                    animation[animationName].time = animationTime;
                    //Debug.Log("Enter and Attached");
                }
                else //放開時
                {
                    DOTween.To(() => animationTime , x => animationTime = x , 0 , 0.3f);
                    animation[animationName].time = animationTime;
                }
            
                //Debug.Log("Enter");

            }
            else //離開區域時
            {
                DOTween.To(() => animationTime , x => animationTime = x , 0 , 0.3f);
                animation[animationName].time = animationTime;
                //Debug.Log("Exit");
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Post(new EnterRepairAreaDetected(this , animationName));
            isEnterArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Post(new EnterRepairAreaDetected(null , null));
            isEnterArea = false;
        }
    }

    public void SetTime(float value)
    {
        animationTime = value;
    }
    
    public void OnAttachedToHand()
    {
        isAttached = true;
        //Debug.Log("Attached Point!!!");

    }
    
    public void OnDetachedToHand()
    {
        isAttached = false;
        //Debug.Log("Detached Point!!!");
    }

    public bool GetIsStop()
    {
        return isStop;
    }
}
