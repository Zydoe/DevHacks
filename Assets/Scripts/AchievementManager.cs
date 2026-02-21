using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;
    public List<Achievement> achievements;

    void Awake()
    {
        Instance = this;
        foreach (var achievement in achievements)
        {
            achievement.LoadState();
        }
    }

    public void UnlockAchievement(string id)
    {
        Achievement achievement = achievements.Find(a => a.id == id);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.Unlock();
            UI_AchievementPopup.Instance.Display(achievement);
        }
    }
}
