using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;



public abstract class BaseUIManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected void ExitUI(GameObject uiObject)
    {
        if(uiObject != null)
        {
            uiObject.SetActive(false);
        }
    }

    protected void OnUI(GameObject uiObject)
    {
        if (uiObject != null)
        {
            uiObject.SetActive(true);
        }
    }

}
