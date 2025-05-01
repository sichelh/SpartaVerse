using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool isRestart = false;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        currentState = GameState.Play;
    }

    public void EndGame()
    {
        currentState = GameState.GameOver;
        isRestart = true;

       
    }

    public bool IsPlaying => currentState == GameState.Play;

}
