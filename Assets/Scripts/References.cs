using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public Player player;
    public DayNightManager dayNightManager;
    public ChaseManager chaseManager;
    public MusicManager musicManager;
    public MenuManager menuManager;
    public ActivateMiniGame activateMiniGame;
    public static References Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Physics2D.queriesHitTriggers = false;
        activateMiniGame = player.GetComponent<ActivateMiniGame>();
    }
    void Start()
    {

    }

}
