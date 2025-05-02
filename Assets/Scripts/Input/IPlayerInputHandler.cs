using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInputHandler
{
    Vector2 GetMoveMentInput();
    bool IsActionPressed();
}
