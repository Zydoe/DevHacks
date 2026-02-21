using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    public float money;
    public AudioClip pickupSound;
    public GameObject audioSourceObject;
    private AudioSource audioSource;
    public static Player Instance { get; private set; }
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

    // Update is called once per frame
    void Update()
    {

    }
    void Start()
    {
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
    }

    public void addMoney(float amount)
    {
        money += amount;
        References.Instance.menuManager.UpdateMoneyDisplay(money);
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }
    public void removeMoney(float amount)
    {
        money -= amount;
    }
    public void addItem(ItemData item)
    {
        addMoney(item.itemValue);
    }
    public void removeItem(ItemData item)
    {
        inventory.removeItem(item);
    }
}
