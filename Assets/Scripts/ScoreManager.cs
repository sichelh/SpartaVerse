using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score { get; private set; } = 0;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int scoreValue)
    {
        Score += scoreValue;

        if(BirdSceneUIManager.Instance != null)
        {
            BirdSceneUIManager.Instance.UpdatePlayingScoreText();
        }
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }

    public void SaveBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (Score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", Score);
            PlayerPrefs.Save();
        }
    }

}
