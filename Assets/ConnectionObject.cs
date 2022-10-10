using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ConnectionObject : MonoBehaviour
{
    [FoldoutGroup("Control Setting")] [SerializeField] private bool canConnect;

    [FoldoutGroup("Control Setting")] [SerializeField] private bool canGrabbable;
    
    [FoldoutGroup("Direction Offset")] [SerializeField] private float offsetRadius;

    [FoldoutGroup("Direction Offset")] [SerializeField] private Vector3[] directionOffset;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (var offset in directionOffset)
        {
            Gizmos.DrawWireSphere(transform.position - offset , offsetRadius);
        }
    }
}
