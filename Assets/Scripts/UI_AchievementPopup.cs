using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class UI_AchievementPopup : MonoBehaviour
{
    public static UI_AchievementPopup Instance;
    public GameObject popupPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public AudioClip achievementSound;
    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        if (popupPanel != null) 
        {
            popupPanel.SetActive(false);
        }
    }

    public void Display(Achievement achievement)
    {
        if (achievementSound != null)
        {
            audioSource.PlayOneShot(achievementSound);
        }

        StopAllCoroutines();
        StartCoroutine(ShowPopup(achievement));
    }

    private IEnumerator ShowPopup(Achievement achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;

        popupPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        popupPanel.SetActive(false);
    }
}