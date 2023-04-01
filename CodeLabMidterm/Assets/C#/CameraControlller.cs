using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.transform.position;
        var cameraPos = this.transform.position;

        if (playerPos.x > -9 && playerPos.x < 9)
        {
            cameraPos.x = playerPos.x;
        }
        if(playerPos.y>-20 && playerPos.y < 4)
        {
            cameraPos.y = playerPos.y;
        }

        this.transform.position = cameraPos;
    }
}
