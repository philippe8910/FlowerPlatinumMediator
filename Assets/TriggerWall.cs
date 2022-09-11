using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TriggerWall : MonoBehaviour , ITrigger
{
    [SerializeField] private Vector3 defaultPos, targetPos;

    public bool isEnter = false;

    private float timer;
    
    public void OnTriggerEnter()
    {
        
    }

    public void OnTriggerStayTrue()
    {
        transform.position = Vector3.Lerp(transform.position , targetPos , 0.5f);
        timer = 0;
    }

    public void OnTriggerStayFalse()
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

    public void OnTriggerExit()
    {
        isEnter = false;
        timer = 0;
    }
}
