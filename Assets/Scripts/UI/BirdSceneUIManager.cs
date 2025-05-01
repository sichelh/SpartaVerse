using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdSceneUIManager : BaseUIManager
{
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    private void Start()
    {
        if (GameManager.Instance.isRestart)
        {
            StartButton();
        }
        else
        {
            GameStartUI();
        }
    }

    public void StartButton()
    {
        StartUI.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void GameStartUI()
    {
        StartUI.SetActive(true);
    }

    public void OpenGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
