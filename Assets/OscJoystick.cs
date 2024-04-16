using System.Collections;
using System.Collections.Generic;
using extOSC;
using UnityEngine;

public class OscJoystick : MonoBehaviour
{
    public FixedJoystick joystick;
    public extOSC.OSCTransmitter oscTranmitter;
    public string address = "/joystick/value";
    
    void Update()
    {
        SenderFloat(address,joystick.Horizontal,joystick.Vertical);
    }

    void SenderFloat(string add, float h, float v)
    {
        var message = new OSCMessage(add);
        var array = OSCValue.Array(); //array로 여러 값을 보낼 수 있도록 하였음
        array.AddValue(OSCValue.Float(v));
        array.AddValue(OSCValue.Float(h));
        message.AddValue(array);
            
        oscTranmitter.Send(message);
    }
}