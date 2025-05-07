using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUIManager : MonoBehaviour
{
    private DungeonGameStartUI GameStartUI;
    private DungeonGameUI GameUI;
    private DungeonGameOverUI GameOverUI;

    private UIState currentState;

    private void Awake()
    {
        GameStartUI = GetComponentInChildren<DungeonGameStartUI>(true);
        GameUI = GetComponentInChildren<DungeonGameUI>(true);
        GameOverUI = GetComponentInChildren<DungeonGameOverUI>(true);

        ChangeState(UIState.DungeonGameStart);
    }

    public void PlayGame()
    {
        ChangeState(UIState.DungeonGame);
        //GameManager.Instance.StartGame();
    }

    public void OpenGameOverUI()
    {
        ChangeState(UIState.DungeonGameOver);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        GameStartUI.SetActive(currentState);
        GameUI.SetActive(currentState);
        GameOverUI.SetActive(currentState);
    }

    public void UpdatePlayingScoreText()
    {
        GameUI.UpdateScoreToString();
    }
}
