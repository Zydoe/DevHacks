using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public GameObject nextPatrolPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Guard")
        {
            collision.gameObject.GetComponent<Guard>().nextPatrolPoint = nextPatrolPoint;
        }
    }
}
