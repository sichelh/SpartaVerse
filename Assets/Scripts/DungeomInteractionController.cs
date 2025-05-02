using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeomInteractionController : MonoBehaviour
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
            mainUIManager.EnterDungeon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainUIManager.ExitDungeon();
        }

    }
}