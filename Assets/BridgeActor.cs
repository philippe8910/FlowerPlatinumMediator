using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActor : MonoBehaviour , ITimeController
{
    [SerializeField] private Animation animation;
    
    public float animationTime { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        animation[animation.name].time = animationTime;
    }

    
    public void OnGrabTime()
    {
        Debug.Log(transform.name +  " : On Grab!!!");
    }

    public void OnRotateTime()
    {
        Debug.Log(transform.name +  " : On Rotate!!!");
    }

    public void OnReleaseTime()
    {
        Debug.Log(transform.name +  " : On Release!!!");
    }
}
