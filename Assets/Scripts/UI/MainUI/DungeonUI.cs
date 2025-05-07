using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonUI : MonoBehaviour
{
    public void LoadDungeonScene()
    {
        SceneManager.LoadScene("DungeonGameScene");
    }

}
