using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInputHandler : MonoBehaviour, IPlayerInputHandler
{
    public Vector2 GetMoveMentInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    public bool IsActionPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
