using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PolygonCollider2D>().isTrigger = false; //right now is collider, not trigger
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            fire.SetActive(true);
            GetComponent<PolygonCollider2D>().isTrigger = true; //once player touched the table, collider change it to trigger => cannot +1
        }
    }
}
