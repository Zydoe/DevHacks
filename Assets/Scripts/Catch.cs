using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player caught by thief!");
            References.Instance.dayNightManager.restartNight();
            other.GetComponent<Player>().addMoney(-1 * other.GetComponent<Player>().money); // Subtract all money for catching the thief
            other.transform.position = References.Instance.playerRespawnPoint.transform.position; // Move player to respawn point
        }
    }
}
