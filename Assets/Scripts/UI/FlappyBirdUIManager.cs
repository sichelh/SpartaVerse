using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdUIManager : BaseUIManager
{
    public static FlappyBirdUIManager Instance { get; private set; }
    
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject PlayUI;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private Text playingScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OpenGameStartUI();
    }

    public void StartButton()
    {
        GameManager.Instance.StartGame();
        Playing();
    }

    public void Playing()
    {
        StartUI.SetActive(false);
        PlayUI.SetActive(true);
    }

    public void OpenGameStartUI()
    {
        StartUI.SetActive(true);
    }

    public void OpenGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    public void UpdatePlayingScoreText()
    {
        playingScoreText.text = ScoreManager.Instance.Score.ToString();
    }

}
