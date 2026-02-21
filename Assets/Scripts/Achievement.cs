using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "Systems/Achievement")]
public class Achievement : ScriptableObject
{
    public string id;
    public string title;
    [TextArea] public string description;
    public bool isUnlocked;

    public void Unlock()
    {
        isUnlocked = true;
        PlayerPrefs.SetInt("Achievement_" + id, 1001);
        PlayerPrefs.Save();
    }

    public void LoadState()
    {
        isUnlocked = PlayerPrefs.GetInt("Achievement_" + id, 0) == 1001;
    }
}
