using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public TextMeshProUGUI timeDisplay;
    public GameObject interactPromptObject;
    private InteractPrompt interactPrompt;
    public GameObject moneyDisplayObject;
    private TextMeshProUGUI moneyDisplay;
    void Start()
    {
        interactPrompt = interactPromptObject.GetComponent<InteractPrompt>();
        moneyDisplay = moneyDisplayObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (WorldData.gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        DayNightManager dayNightManager = GetComponent<DayNightManager>();
        timeDisplay.text = dayNightManager.isDay ? "Day " + WorldData.currentDay : dayNightManager.currentTime == 0 ? 12 + " AM" : dayNightManager.currentTime + " AM";
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        WorldData.gamePaused = false;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        WorldData.gamePaused = true;
    }
    public void ShowInteractPrompt(string text, string button)
    {
        interactPromptObject.SetActive(true);
        interactPrompt.SetPromptText(text, button);
    }
    public void HideInteractPrompt()
    {
        interactPromptObject.SetActive(false);
    }

    public void UpdateMoneyDisplay(float money)
    {
        moneyDisplay.text = "$ " + money.ToString();
    }
}
