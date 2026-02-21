using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    bool playerInRange = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DayNightManager dayNightManager = FindObjectOfType<DayNightManager>();
            if (dayNightManager != null)
            {
                if (dayNightManager.isDay)
                    dayNightManager.startNight();
                else
                    dayNightManager.startDay();
            }
        }
    }
}
