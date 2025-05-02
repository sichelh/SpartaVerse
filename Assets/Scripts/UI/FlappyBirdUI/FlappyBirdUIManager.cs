using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdUIManager : MonoBehaviour
{
    
    private FlappyBirdGameStartUI GameStartUI;
    private FlappyBirdGameUI GameUI;
    private FlappyBirdGameOverUI GameOverUI;

    private UIState currentState;

    private void Awake()
    {
        GameStartUI = GetComponentInChildren<FlappyBirdGameStartUI>(true);
        GameUI = GetComponentInChildren<FlappyBirdGameUI>(true);
        GameOverUI = GetComponentInChildren<FlappyBirdGameOverUI>(true);

        ChangeState(UIState.FlappyBirdGameStart);
    }

    public void PlayGame()
    {
        ChangeState(UIState.FlappyBirdGame);
        GameManager.Instance.StartGame();
    }

    public void OpenGameOverUI()
    {
        ChangeState(UIState.FlappyBirdGameOver);
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
