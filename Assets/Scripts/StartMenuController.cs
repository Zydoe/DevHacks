using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public TextMeshProUGUI startButtonText;
    public References references;
    public static StartMenuController Instance { get; private set; }
    public void onStartButtonClicked()
    {
        startButtonText.text = "Continue";
        references.menuManager.ResumeGame();
    }

    public void onOptionsButtonClicked()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void onExitButtonClicked()
    {
        Application.Quit();
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
