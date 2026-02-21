using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartingPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
