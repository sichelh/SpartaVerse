using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGameStartUI : BaseUI
{
    protected override UIState GetUIState()
    {
        return UIState.DungeonGameStart;
    }

    protected DungeonUIManager uiManager;
    public void Awake()
    {
        uiManager = FindObjectOfType<DungeonUIManager>();
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickStartButton()
    {
        uiManager.PlayGame();
    }
}
