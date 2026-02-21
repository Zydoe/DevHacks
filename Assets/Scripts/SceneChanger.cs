using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SceneChanger : MonoBehaviour
{
    public String sceneToLoad;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            WorldData.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        }
    }
}
