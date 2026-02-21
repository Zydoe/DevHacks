using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance { get; private set; }

    public static event System.Action OnNightStarted;
    public static event System.Action OnDayStarted;

    public GameObject light;
    private Light2D globalLight;
    public float dayBrightness = 1f;
    public float nightBrightness = 0.05f;
    int timePerHour = 30;
    int currentTime = 0;
    public bool isDay = true;
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
        isDay = false;
        StartCoroutine(nightTimer());
        globalLight.intensity = nightBrightness;
        OnNightStarted?.Invoke();
    }

    void startDay()
    {
        isDay = true;
        WorldData.currentDay++;
        globalLight.intensity = dayBrightness;
        currentTime = 0;
        StopAllCoroutines();
        OnDayStarted?.Invoke();
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
