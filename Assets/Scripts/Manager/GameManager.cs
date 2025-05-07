using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{ 
    Ready, 
    Play, 
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState { get; private set; } = GameState.Ready;

    float goMainDelay = 2f;

    public bool IsPlaying => currentState == GameState.Play;
    bool gameOver = false;

    float elapsedTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ScoreManager.Instance.ResetScore();
    }

    private void Update()
    {
        if (gameOver)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= goMainDelay)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    public void StartGame()
    {
        currentState = GameState.Play;
    }

    public void EndGame()
    {
        currentState = GameState.GameOver;
        ScoreManager.Instance.SaveBestScore();
        ScoreManager.Instance.SaveLastScore();
        gameOver = true;
    }


}
