using System.Collections;
using System.Collections.Generic;
using Autohand;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Grabbable))]
public class DialTimeRotateAction : MonoBehaviour
{
    public GameObject targetTimeController;

    private ITimeController timeController;

    private Grabbable grabbable;

    private bool isGrab;
    
    // Start is called before the first frame update
    void Start()
    {
        if(targetTimeController == null)
            Debug.LogError(this.gameObject.name + "Has not inpput target Time Controller!!!");

        targetTimeController.TryGetComponent<ITimeController>(out var _timeController);
        transform.TryGetComponent<Grabbable>(out var _grabbable);
        
        timeController = _timeController;
        grabbable = _grabbable;
        
        grabbable.onGrab.AddListener(delegate(Hand arg0, Grabbable grabbable1) { timeController.OnGrabTime();});
        grabbable.onGrab.AddListener(delegate(Hand arg0, Grabbable grabbable1) { isGrab = true;  });
        
        grabbable.onRelease.AddListener(delegate(Hand arg0, Grabbable grabbable1) { timeController.OnReleaseTime(); });
        grabbable.onRelease.AddListener(delegate(Hand arg0, Grabbable grabbable1) { isGrab = false; });

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrab)
        {
            timeController.OnReleaseTime();
        }
    }



    #region ComputerTest

    [Button]
    private void GrabTest()
    {
        Hand hand = null;
        Grabbable grab = null;
        
        grabbable.onGrab.Invoke(hand , grab);
    }
    
    [Button]
    private void RotateTest()
    {
        if (isGrab)
        {
            //Debug.Log( transform.name + " : On Rotate");
        }
    }
    
    [Button]
    private void ReleaseTest()
    {
        Hand hand = null;
        Grabbable grab = null;
        
        grabbable.onRelease.Invoke(hand , grab);
    }

    #endregion
}
