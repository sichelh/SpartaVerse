using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    public void ToStringGameEndUI()
    {
        int score = ScoreManager.Instance.GetLastScore();
        scoreText.text = score.ToString();

        int bestScore = ScoreManager.Instance.GetBestScore();
        bestScoreText.text = bestScore.ToString();
    }

    public void OnClickExitButton()
    {
        this.gameObject.SetActive(false);
    }
}
