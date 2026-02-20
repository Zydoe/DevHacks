using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance { get; private set; }

    public GameObject light;
    private Light2D globalLight;
    public float dayBrightness = 1f;
    public float nightBrightness = 0.05f;
    int timePerHour = 30;
    int currentTime = 0;
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

    void Start()
    {
        globalLight = light.GetComponent<Light2D>();
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
        StartCoroutine(nightTimer());
        globalLight.intensity = nightBrightness;
    }

    void startDay()
    {
        WorldData.currentDay++;
        globalLight.intensity = dayBrightness;
        currentTime = 0;
        StopAllCoroutines();
    }
    IEnumerator nightTimer()
    {
        yield return new WaitForSeconds(timePerHour);
        currentTime++;
        if (currentTime >= 6)
        {
            startDay();
        }
    }
    public void restartNight()
    {
        currentTime = 0;
        StartCoroutine(nightTimer());
    }
}
