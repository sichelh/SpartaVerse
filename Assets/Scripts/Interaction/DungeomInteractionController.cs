using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeomInteractionController : MonoBehaviour
{
    [SerializeField] private MainUIManager mainUIManager;

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