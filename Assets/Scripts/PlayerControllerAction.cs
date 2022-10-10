using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using Valve.VR;

public class PlayerControllerAction : MonoBehaviour
{
    [FoldoutGroup("Anchor")] [SerializeField] private Transform forwardAnchor, rightAnchor , cameraAnchor;
    
    [SerializeField] private SteamVR_Action_Vector2 touchpadPos;

    [SerializeField] private SteamVR_Action_Boolean runButton;

    [SerializeField] private SteamVR_Action_Boolean jumpButton;

    [SerializeField] private SteamVR_Action_Boolean dropDoppelgangerAction;
    
    [SerializeField] private SteamVR_Action_Boolean stopTimeAction;

    public bool isComputer;
    // Start is called before the first frame update
    void Start()
    {
        if (forwardAnchor == null) forwardAnchor = GameObject.Find("ForwardAnchor").transform;
        if (rightAnchor == null) rightAnchor = GameObject.Find("RightAnchor").transform;
        if (cameraAnchor == null) cameraAnchor = Camera.main.transform;


        //touchpadPos.activeDevice = SteamVR_Input_Sources.LeftHand;

    }

    // Update is called once per frame
    void Update()
    {
        if (isComputer)
        {
//            Debug.Log(new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical")));
            EventBus.Post(new JoystickInputDetected(new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical"))));
        }
        else
        {
//            Debug.Log(touchpadPos.axis);
            EventBus.Post(new JoystickInputDetected(touchpadPos.axis));
        }
    }

    private Vector2 InputHorizontal()
    {
        return touchpadPos.axis.x * (rightAnchor.position - cameraAnchor.position);
    }
    
    private Vector2 InputVertical()
    {
        return touchpadPos.axis.y * (forwardAnchor.position - cameraAnchor.position);
    }

    public Vector2 GetInput()
    {
        return InputHorizontal() + InputVertical();
    }
    

    public bool GetRunButton()
    {
        return runButton.stateDown;
    }

    public bool GetJumpButton()
    {
        if (isComputer)
        {
            return Input.GetButtonDown("Jump");
        }
        else
        {
            return jumpButton.stateDown;
        }
    }

    public bool GetDropdropDoppelgangerAction()
    {
        return dropDoppelgangerAction.stateDown;
    }

    public bool GetStopTimeAction()
    {
        return stopTimeAction.stateDown;
    }
}
