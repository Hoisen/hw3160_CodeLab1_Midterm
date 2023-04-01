using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;

    private Animator anim;

    GameObject FinalLight;
    
    private float time;
    public TextMeshPro textMeshPro;
    public GameObject tmp;
    private bool tmpBool = false;

    public GameObject finalDoor;
    //public GameObject fire;

    //public GameObject tablewFire;
    

    //public Light2D light;
    
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        time = 8;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (GameData.countTable >= 4)
        {
            //light.intensity = Mathf.PingPong(Time.time, 1f);
            //anim.SetBool("Go", true);
        }

        if (moveSpeed <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        }

        if (tmpBool == true)
        {
            time -= Time.deltaTime;
            textMeshPro.text =
                "Timer: " + time;
        }

        if (time <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "timer")
        {
            tmp.SetActive(true);
            time = 8;
            tmpBool = true;
            finalDoor.SetActive(true);
        }

        if (col.tag == "finaldoor")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        }
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "table")
        {
            Debug.Log("Triggered the table!");
            GameData.countTable += 1;
        }

        if (col.gameObject.tag == "enemy")
        {
            moveSpeed -= .5f;
            Debug.Log(moveSpeed);
        }
    }
    
}
