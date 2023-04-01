using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private Transform player;

    private float speed = 1f;

    private int MaxDist = 5;

    private int MinDist = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "table")
        {
            //Destroy(this);
            Debug.Log("AAAA");
        }
        
        if (col.gameObject.tag == "Player")
        {
            transform.position = new Vector2(
                Random.Range(-9f, 9f),
                Random.Range(-4f, 4f));
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "finalLight")
        {
            Destroy(this);
        }
    }
    
    
}