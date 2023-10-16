using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{

    [SerializeField] GameObject player;
    
    [SerializeField] BoxCollider2D ground;

    [SerializeField] GameObject floor;  
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
        ground = floor.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(player.transform.position.y< ground.transform.position.y)
        {
            ground.enabled = false;
        }
        else if(player.transform.position.y <= ground.transform.position.y)
        {
            ground.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetAxis("Vertical") > 0.01 && player.transform.position.y > transform.position.y)
        {
            ground.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetAxis("Vertical") < -0.01)
        {
            ground.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" &&  player.transform.position.y < transform.position.y)
        {
            ground.enabled = false;
            Debug.Log("Collide");
        }
    }
}
