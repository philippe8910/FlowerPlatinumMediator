using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindAnchorPoint : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public CharacterStateAction actor;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        actor = FindObjectOfType<CharacterStateAction>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0 , transform.position);
        lineRenderer.SetPosition(1 , actor.transform.position);
    }
}
