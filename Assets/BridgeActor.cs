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
        
    }

    public void OnRotateTime()
    {
        
    }

    public void OnReleaseTime()
    {
        
    }
}
