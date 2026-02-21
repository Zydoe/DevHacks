using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractPrompt : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public TextMeshProUGUI buttonText;
    public void SetPromptText(string text, string button)
    {
        promptText.text = text;
        buttonText.text = button;
    }
}
