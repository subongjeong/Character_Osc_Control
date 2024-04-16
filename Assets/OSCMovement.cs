using System.Collections;
using System.Collections.Generic;
using extOSC;
using UnityEngine;

public class OSCMovement : MonoBehaviour
{
    public extOSC.OSCReceiver oscReceiver;
    public string address = "/joystick/value";
    public MovementManager movementManager;
    
    void Start()
    {
        oscReceiver.Bind(address, ReceivedMessage);
    }

    void ReceivedMessage(extOSC.OSCMessage message)
    {
        if (message.ToArray(out var arrayValues))
        {
            movementManager.SetVertical(arrayValues[0].FloatValue);
            movementManager.SetHorizontal(arrayValues[1].FloatValue);
        }
    }
}
