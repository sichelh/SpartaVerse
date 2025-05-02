using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;



public abstract class BaseUIManager : MonoBehaviour
{
    protected void QuitGame()
    {
        Application.Quit();
    }
}
