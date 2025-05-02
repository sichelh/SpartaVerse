using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    Vector2 GetMoveMentInput();
    bool IsActionPressed();
}
