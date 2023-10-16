using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Visuals")]
    public SpriteRenderer playerSprite;
    public Animator animator;

    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;

    [Header ("Forces")]
    private float inputX;
    private float inputY;
    [SerializeField] float jumpForce = 10;
    

    int jumpCount = 1;

    [Header ("Is Grounded Checks")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

 




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Debug.Log(inputY + ", " + inputX);
        
        PlayerLands();
        MovePlayer();
        PlayerJump();
        

        animator.SetFloat("Speed", Mathf.Abs(inputX));
    }

    private void PlayerLands()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector2(groundCheck.position.x, groundCheck.position.y), groundDistance, groundMask);

        Debug.Log(isGrounded);

        if (isGrounded == true && rb.velocity.y < 0.01)
        {
            jumpCount = 1;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
        else if(isGrounded == false && rb.velocity.y < 0.01)
        {
            animator.SetBool("isFalling", true);
        }
    }

    private void GetInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

    }

    private void MovePlayer()
    {
        rb.velocity += new Vector2 (inputX * moveSpeed,0) * Time.deltaTime;

        if(inputX > 0.01 && isGrounded)
        {
            playerSprite.flipX = false;
        }
        else if (inputX < -0.01 && isGrounded)
        {
            playerSprite.flipX = true;
        }
    }

    private void PlayerJump()
    {
        

        if (Input.GetKeyDown(KeyCode.W) && jumpCount >= 1 && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
    }

    
}
