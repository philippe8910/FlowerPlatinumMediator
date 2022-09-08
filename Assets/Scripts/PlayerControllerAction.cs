using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;
using Valve.VR;

public class PlayerControllerAction : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Vector2 touchpadPos;

    [SerializeField] private SteamVR_Action_Boolean runButton;

    [SerializeField] private SteamVR_Action_Boolean jumpButton;

    [SerializeField] private SteamVR_Action_Boolean dropDoppelgangerAction;

    public bool isComputer;
    // Start is called before the first frame update
    void Start()
    {
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
}
