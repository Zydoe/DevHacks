using UnityEngine;

public class ActivateMiniGame : MonoBehaviour
{
    public BarMiniGame miniGameScript;

    public void StartMiniGame()
    {
        References.Instance.menuManager.HideInteractPrompt();
        if (miniGameScript != null)
        {
            miniGameScript.showMiniGame();
        }
    }
}