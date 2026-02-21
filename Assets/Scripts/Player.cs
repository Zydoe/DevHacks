using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    public float money;
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

    public void addMoney(float amount)
    {
        money += amount;
    }
    public void removeMoney(float amount)
    {
        money -= amount;
    }
    public void addItem(ItemData item)
    {
        inventory.addItem(item);
        Debug.Log("Added " + item.itemName + " to inventory");
    }
    public void removeItem(ItemData item)
    {
        inventory.removeItem(item);
    }
}
