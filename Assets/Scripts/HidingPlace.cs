using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public bool playerInRange = false;
    public References references;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //Toggle hiding
            Player player = references.player;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

            if (!playerMovement.isHiding)
            {
                player.transform.position = transform.position;
                player.GetComponent<SpriteRenderer>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.GetComponent<Collider2D>().enabled = false;
                playerMovement.isHiding = true;
            }
            else
            {
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<Collider2D>().enabled = true;
                playerMovement.isHiding = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
