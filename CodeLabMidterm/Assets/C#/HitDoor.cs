using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDoor : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameManager.instance.GetComponent<ASCIILevelLoadScript>().HitDoor();
            door.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = null;//destory is not working here, set active(false) => sprite still there
            Destroy(this); //so i use both
        }
    }

    public void MouseClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    public void StartClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
