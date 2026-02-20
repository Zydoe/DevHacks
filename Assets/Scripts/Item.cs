using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
public class Item : MonoBehaviour
{
    public ItemData itemData;
    public bool playerInRange;
    private Collider2D player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerPickup();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            player = collision;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    void playerPickup()
    {
        player.GetComponent<Player>().addItem(itemData);
        Destroy(gameObject);
    }
}
