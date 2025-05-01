using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    GoBirdGameUI
}

public class UIManager : MonoBehaviour
{
    GoBirdGameUI goBirdGameUI;

    private UIState currentState;

    private void Awake()
    {
        goBirdGameUI = GetComponentInChildren<GoBirdGameUI>(true);
        goBirdGameUI.Init(this);

    }

    public void OnUIState(UIState state)
    {
        currentState = state;
        goBirdGameUI.SetActive(currentState);
    }

}
