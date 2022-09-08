using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TriggerWall : MonoBehaviour , ITrigger
{
    [SerializeField] private Vector3 defaultPos, targetPos;
    
    public void OnTriggerEnter()
    {
        
    }

    public void OnTriggerStayTrue()
    {
        transform.position = Vector3.Lerp(transform.position , targetPos , 0.1f);
    }

    public void OnTriggerStayFalse()
    {
        transform.position = Vector3.Lerp(transform.position , defaultPos , 0.1f);

    }

    public void OnTriggerExit()
    {
        
    }
}
