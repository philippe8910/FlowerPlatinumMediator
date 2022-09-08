using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    private bool isTrigger = false;

    private ITrigger ItriggerObject;

    [SerializeField] private GameObject triggerObject;

    [SerializeField] private Material onTriggerMaterial, disTriggerMaterial;
    void Start()
    {
        onTriggerMaterial = Resources.Load<Material>("TestMaterial/TriggerMaterial");
        disTriggerMaterial = Resources.Load<Material>("TestMaterial/DisTriggerMaterial");

        ItriggerObject = triggerObject.GetComponent<TriggerWall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            ItriggerObject.OnTriggerStayTrue();
        }
        else
        {
            ItriggerObject.OnTriggerStayFalse();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        GetComponent<MeshRenderer>().material = onTriggerMaterial;
        ItriggerObject.OnTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
        GetComponent<MeshRenderer>().material = onTriggerMaterial;
        ItriggerObject.OnTriggerExit();
    }
}
