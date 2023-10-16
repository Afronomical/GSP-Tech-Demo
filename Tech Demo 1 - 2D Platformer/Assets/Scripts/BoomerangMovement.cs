using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoomerangMovement : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playerScript;
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float step;
    [SerializeField] float flightTime = 1;
    [SerializeField] float boomerangSpeed = 5;
    [SerializeField] float returnSpeed = 0.1f;

    [SerializeField] bool isReturning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
        playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite").GetComponent<SpriteRenderer>();

        StartCoroutine(BoomerangThrow());
        if (playerSprite.flipX == true)
        {
            // transform.position = gameObject.transform.position + 
            boomerangSpeed *= -1;
        }
        else if (playerSprite.flipX == false)
        {
            boomerangSpeed *= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            isReturning = true;
            IInteractable interactable = collision.GetComponent<IInteractable>();

            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (isReturning)
        {
            Return();
        }
        else
        {
            Away();
            
        }
        
    }

    private void Return()
    {
        boomerangSpeed = 0;
        //gameObject.transform.position = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0)//Vector3.MoveTowards(transform.position, player.transform.position, step);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, returnSpeed);

        if (transform.position == player.transform.position)
        {
            Destroy(gameObject);
        }
    }

    private void Away()
    {
        rb.velocity = new Vector3(boomerangSpeed, 0, 0);
    }
    

    IEnumerator BoomerangThrow()
    {
        isReturning = false;
        yield return new WaitForSeconds(flightTime/2);

        //boomerangSpeed *= -1;

        isReturning = true;
        yield return new WaitForSeconds(flightTime/2);

        
    }


}
