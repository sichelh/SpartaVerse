using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : BaseUIManager
{
    [SerializeField] private GameObject goBirdGameUI;

    public void OpenBirdGameUI()
    {
        OnUI(goBirdGameUI);
    }

    public void ExitBirdGameUI()
    {
        ExitUI(goBirdGameUI);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("BirdGameScene");
    }
}
