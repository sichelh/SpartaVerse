using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGameUI : BaseUI
{
    [SerializeField] private Text playingScoreText;
    protected override UIState GetUIState()
    {
        return UIState.DungeonGame;
    }

    public void UpdateScoreToString()
    {
        //playingScoreText.text = Score.ToString();
    }

}
