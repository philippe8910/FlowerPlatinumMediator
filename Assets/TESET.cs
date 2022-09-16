using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESET : MonoBehaviour
{
    [SerializeField] private Transform camera, anchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dis = camera.position - anchor.position;
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position += new Vector3(dis.x, 0, dis.z) * Time.deltaTime;
            Debug.Log("work");

        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position -= new Vector3(dis.x, 0, dis.z) * Time.deltaTime;
            Debug.Log("work");
        }
    }
}
