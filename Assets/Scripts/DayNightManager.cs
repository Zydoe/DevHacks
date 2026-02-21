using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    public static event System.Action OnNightStarted;
    public static event System.Action OnDayStarted;

    public GameObject lightObject;
    private Light2D globalLight;
    public MusicManager musicManager;
    public float dayBrightness = 1f;
    public float nightBrightness = 0.05f;
    int timePerHour = 30; //seconds per hour
    public int currentTime = 0;
    public bool isDay = true;


    void Start()
    {
        globalLight = lightObject.GetComponent<Light2D>();
        musicManager = GetComponent<MusicManager>();
        if (isDay)
        {
            startDay();
        }
        else
        {
            startNight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WorldData.developerMode)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                startNight();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                startDay();
            }
        }
    }

    public void startNight()
    {
        isDay = false;
        StartCoroutine(nightTimer());
        globalLight.intensity = nightBrightness;
        musicManager.PlayNightMusic();
        OnNightStarted?.Invoke();
    }

    void startDay()
    {
        isDay = true;
        WorldData.currentDay++;
        globalLight.intensity = dayBrightness;
        currentTime = 0;
        StopAllCoroutines();
        musicManager.PlayDayMusic();
        OnDayStarted?.Invoke();
    }
    IEnumerator nightTimer()
    {
        while (currentTime < 6)
        {
            yield return new WaitForSeconds(timePerHour);
            currentTime++;
        }
        startDay();
    }
    public void restartNight()
    {
        currentTime = 0;
        StartCoroutine(nightTimer());
    }
}
