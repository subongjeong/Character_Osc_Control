using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public FixedJoystick joystick;
    public MovementManager movementManager;

    void Update()
    {
        //조이스틱의 H,V 값을 movementManeger의 SetHorizontal, SetVertical이라는 public 함수로 전달한다.
        print(joystick.Horizontal +"," + joystick.Vertical);
        
        movementManager.SetHorizontal(joystick.Horizontal);
        movementManager.SetVertical(joystick.Vertical);
    }
}