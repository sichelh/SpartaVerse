using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputHandler : MonoBehaviour, IPlayerInputHandler
{
    public Vector2 GetMoveMentInput()
    {
        return Vector2.zero;
    }

    public bool IsActionPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

}
