using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOtherControllerCHANGE : MonoBehaviour
{
    public PlayerControllerCHANGE player;
    private Animator animator;
    private bool isGrounded;
    private bool isChangeSizeSmall;
    private bool isChangeSizeBig;
    public bool Switched = false;
    /// <summary>
    /// </summary>
    public bool isActive = true;
    void Start()
    {
      
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            return;
        }
        float moveInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(player.groundCheck.position, player.checkRadius, player.groundLayer);
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleSizeBig();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleSizeSmall();
        }
        // Set the isMoving parameter based on player input
        animator.SetBool("isMoving", Mathf.Abs(moveInput) > 0);
        // Set the isGrounded parameter
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("switched", Switched);
        // Flip the sprite based on the movement direction
        if (moveInput > 0)
        {
            if (isChangeSizeBig)
            {
                transform.localScale = Vector3.one * 5;
            }
            else if (isChangeSizeSmall)
            {
                transform.localScale = Vector3.one * 2;
            }
            else
            {
                transform.localScale = Vector3.one * 3;
            }

        }
        else if (moveInput < 0)
        {

            if (isChangeSizeBig)
            {
                transform.localScale = new Vector3(-5, 5, 5);
            }
            else if (isChangeSizeSmall)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {
                transform.localScale = new Vector3(-3, 3, 3);
            }

        }
    }
    /// <summary>
    /// </summary>
    private void ToggleSizeBig()
    {
        if (isChangeSizeBig)
        {
            ToggleSizeNormal();
            isChangeSizeBig = false;
            isChangeSizeSmall = false;
        }
        else
        {
            isChangeSizeBig = true;
            isChangeSizeSmall = false;
            player.groundCheck.transform.localScale = Vector3.one * 5f;
            player.jumpForce = 12;
            // moveSpeed = 2;
        }
    }
    /// <summary>
    /// </summary>
    private void ToggleSizeSmall()
    {
        if (isChangeSizeSmall)
        {
            ToggleSizeNormal();
            isChangeSizeSmall = false;
            isChangeSizeBig = false;
        }
        else
        {
            isChangeSizeBig = false;
            isChangeSizeSmall = true;
            player.groundCheck.transform.localScale = Vector3.one * 2f;
            player.jumpForce = 5;
        }
    }
    /// <summary>
    /// </summary>
    private void ToggleSizeNormal()
    {
        player.jumpForce = 10;
        player.groundCheck.transform.localScale = Vector3.one * 3;
    }

}
