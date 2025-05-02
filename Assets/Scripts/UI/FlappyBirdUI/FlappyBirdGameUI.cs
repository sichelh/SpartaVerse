using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdGameUI : BaseUI
{
    [SerializeField] private Text playingScoreText;

    protected override UIState GetUIState()
    {
        return UIState.FlappyBirdGame;
    }

    public void UpdateScoreToString()
    {
        playingScoreText.text = ScoreManager.Instance.Score.ToString();
    }
}
