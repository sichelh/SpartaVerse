using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntreactionController : MonoBehaviour
{
    private MainUIManager mainUIManager;
    

    private void Awake()
    {
        mainUIManager = FindObjectOfType<MainUIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainUIManager.OpenBirdGameUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainUIManager.ExitBirdGameUI();
        }
        
    }
}
