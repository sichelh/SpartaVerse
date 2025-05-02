using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : BaseUIManager
{
    [SerializeField] private GameObject FlappyBirdGameUI;
    [SerializeField] private Text GameEndTitleText;

    public bool isFlappyBirdUIActive = false;

    GameEndUIManager gameEndUIManager;

    private void Awake()
    {
        gameEndUIManager = GetComponent<GameEndUIManager>();
    }

    private void Start()
    {
        if (ScoreManager.Instance != null)
        {
            gameEndUIManager.OpenGameEndUI();
            GameEndTitleText.text = ScoreManager.Instance.result ? "Success update BestScore!" : "Fail update BestScore...";
        }

        
    }

    public void OpenBirdGameUI()
    {
        OnUI(FlappyBirdGameUI);
        isFlappyBirdUIActive = true;
    }

    public void ExitBirdGameUI()
    {
        ExitUI(FlappyBirdGameUI);
        isFlappyBirdUIActive = false;
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("FlappyBirdGameScene");
    }
}
