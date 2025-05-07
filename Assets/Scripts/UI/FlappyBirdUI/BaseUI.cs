using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    FlappyBirdGameStart,
    FlappyBirdGame,
    FlappyBirdGameOver
}

public abstract class BaseUI : MonoBehaviour
{
    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
