using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdSceneUIManager : BaseUIManager
{
    public static BirdSceneUIManager Instance { get; private set; }
    
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject PlayUI;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    [SerializeField] private Text playingScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayUI.SetActive(false);
        ScoreManager.Instance.ResetScore();

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
        PlayUI.SetActive(true);
    }

    public void GameStartUI()
    {
        StartUI.SetActive(true);
    }

    public void OpenGameOverUI()
    {
        int score = ScoreManager.Instance.Score;
        scoreText.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = bestScore.ToString();
        
        GameOverUI.SetActive(true);
    }

    public void UpdatePlayingScoreText()
    {
        playingScoreText.text = ScoreManager.Instance.Score.ToString();
    }

}
