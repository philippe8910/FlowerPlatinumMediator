using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESET : MonoBehaviour
{
    public Transform camera, ancher;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (camera.position - ancher.position) * Time.deltaTime;
    }
}
