using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdGameStartUI : BaseUI
{
    protected FlappyBirdUIManager uiManager;
    public void Awake()
    {
        uiManager = FindObjectOfType<FlappyBirdUIManager>();
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickStartButton()
    {
        uiManager.PlayGame();
    }

    protected override UIState GetUIState()
    {
        return UIState.FlappyBirdGameStart;
    }
}
