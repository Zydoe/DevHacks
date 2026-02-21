using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInteractable : MonoBehaviour
{
    private ActivateMiniGame minigame;
    public bool isInRange;

    void Start()
    {
        minigame = References.Instance.activateMiniGame;
        References.Instance.menuManager.HideInteractPrompt();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            minigame.StartMiniGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            References.Instance.menuManager.ShowInteractPrompt("LockPick", "[E]");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            References.Instance.menuManager.HideInteractPrompt();
        }
    }
}
