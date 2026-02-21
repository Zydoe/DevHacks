using UnityEngine;

public class ActivateMiniGame : MonoBehaviour
{
    public BarMiniGame miniGameScript;

    void Update()
    {
        // for now, tab runs the game again but we can use something else to trigger it
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (miniGameScript != null)
            {
                miniGameScript.showMiniGame();
            }
        } // end of if
    }
}
