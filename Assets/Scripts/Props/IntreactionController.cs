using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntreactionController : MonoBehaviour
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiManager.OnUIState(UIState.GoBirdGameUI);
        }
    }
}
