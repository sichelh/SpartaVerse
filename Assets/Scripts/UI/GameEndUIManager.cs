using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUIManager : BaseUIManager
{
    [SerializeField] private GameObject GameEndUI;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    public void OpenGameEndUI()
    {
        int score = ScoreManager.Instance.GetLastScore();
        scoreText.text = score.ToString();

        int bestScore = ScoreManager.Instance.GetBestScore();
        bestScoreText.text = bestScore.ToString();

        GameEndUI.SetActive(true);
    }

    public void ExitGameEndUI()
    {
        ExitUI(GameEndUI);
    }
}
