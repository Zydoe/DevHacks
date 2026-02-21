using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    List<GameObject> guards = new List<GameObject>();
    public bool playerInChase = false;

    public void JoinChase(GameObject guard)
    {
        playerInChase = true;
        guards.Add(guard);
    }
    public void LeaveChase(GameObject guard)
    {
        guards.Remove(guard);
        if (guards.Count == 0)
        {
            playerInChase = false;
        }
    }
}
