using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public Vector3 lastKnownPlayerPosition;
    public bool playerInSight = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastKnownPlayerPosition = Vector3.zero;
            playerInSight = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastKnownPlayerPosition = collision.gameObject.transform.position;
            playerInSight = false;
        }
    }
}
