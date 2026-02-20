using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void onStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }  // end of onStartButtonClicked

    public void onOptionsButtonClicked()
    {
        SceneManager.LoadScene("OptionsMenu");
    }  // end of onOptionsButtonClicked

    public void onExitButtonClicked()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }  // end of onExitButtonClicked
}
