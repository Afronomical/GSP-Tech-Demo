using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 10f;
    private bool isLadder = false;
    private bool isClimbing = false;

    private PlayerMovement playerMove;
    private JetpackPowerUp jetPack;

    private float currentGravity = 1;

    public Rigidbody2D rb;

    private void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        jetPack = GetComponent<JetpackPowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0.01) 
        {
            isClimbing= true;
        }
    }


    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, vertical * speed);
        }
        else
        {
           
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove.gameObject.transform.position = new Vector3(transform.position.x, playerMove.transform.position.y, playerMove.transform.position.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && Mathf.Abs(Input.GetAxis("Horizontal")) <= 0.01)
        {
            LadderClimb();
        }
        if (collision.tag == "Ladder" && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01)
        {
            NotClimb();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            NotClimb();
        }
    }

    private void LadderClimb()
    {
        isLadder = true;
        rb.velocity = new Vector2(0, 0);

        playerMove.enabled = false;
        jetPack.enabled = false;
    }
    private void NotClimb()
    {
        isLadder = false;
        isClimbing = false;

        rb.gravityScale = currentGravity;
        playerMove.enabled = true;
        jetPack.enabled = true;
    }
}
