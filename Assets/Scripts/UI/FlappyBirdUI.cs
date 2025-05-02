using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdUI : MonoBehaviour
{
    public void LoadFlappyBirdScene()
    {
        SceneManager.LoadScene("FlappyBirdGameScene");
    }

}
