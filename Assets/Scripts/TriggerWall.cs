using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TriggerWall : MonoBehaviour , ITrigger
{
    [SerializeField] private Vector3 defaultPos, targetPos;

    public bool isEnter = false;

    public float timer;
    
    public virtual void OnTriggerEnter()
    {
        
    }

    public virtual void OnTriggerStayTrue()
    {
        transform.position = Vector3.Lerp(transform.position , targetPos , 0.5f);
        timer = 0;
    }

    public virtual void OnTriggerStayFalse()
    {
        if (isEnter)
        {
            transform.position = Vector3.Lerp(transform.position , defaultPos , 0.5f);
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

    public virtual void OnTriggerExit()
    {
        isEnter = false;
        timer = 0;
    }
}
