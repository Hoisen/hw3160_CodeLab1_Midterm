using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level0LightOn : MonoBehaviour
{
    private Animator anim;

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.countTable == 4)
        {
            anim.SetBool("Go", true);
            door.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("found enemyyy");
            
        }
    }
}
