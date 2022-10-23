using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Gemini : MonoBehaviour
{
    [SerializeField] private Transform geminiTarget;

    [SerializeField] private float limitPosMax , limitPosMin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var value = Mathf.Clamp(-geminiTarget.position.y, limitPosMin, limitPosMax);
        
        transform.position = new Vector3(transform.position.x, value, transform.position.z);
    }
}
