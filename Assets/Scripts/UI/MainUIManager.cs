using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private Text GameEndTitleText;

    private UIState currentState;

    public bool isFlappyBirdUIActive = false;
    public bool isDungeonUIActive = false;

    [SerializeField] private GameObject gameEndUI;
    [SerializeField] private GameObject flappyBirdUI;
    [SerializeField] private GameObject dungeonUI;

    private void Start()
    {
        if (ScoreManager.Instance != null)
        {
            gameEndUI.SetActive(true);
            gameEndUI.GetComponent<GameEndUI>().ToStringGameEndUI();
            GameEndTitleText.text = ScoreManager.Instance.result ? "Success update BestScore!" : "Fail update BestScore...";
        }
    }

    public void EnterFlappyBird()
    {
        flappyBirdUI.SetActive(true);
        isFlappyBirdUIActive = true;
    }

    public void ExitFlappyBird()
    {
        if (flappyBirdUI != null)
        {
            flappyBirdUI.SetActive(false);
            isFlappyBirdUIActive = false;
        }
    }

    public void EnterDungeon()
    {
        dungeonUI.SetActive(true);
        isDungeonUIActive = true;
    }

    public void ExitDungeon()
    {
        dungeonUI.SetActive(false);
        isDungeonUIActive = false;
    }

    public void LoadFlappyBirdGame()
    {
        flappyBirdUI.GetComponent<FlappyBirdUI>().LoadFlappyBirdScene();
    }

    public void LoadDungeomGame()
    {
        dungeonUI.GetComponent<DungeonUI>().LoadDungeonScene();
    }
}
