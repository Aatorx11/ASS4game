using UnityEngine;

public class PlayerControllerCHANGE : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = 0.5f;

   
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isChangeSizeSmall;
    private bool isChangeSizeBig;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    public bool Switched = false;
    /// <summary>
    /// �Ƿ񼤻������
    /// </summary>
    public bool isActive = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isActive == false)
        {          
            return;
        }
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    
        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift)) //CHANGE
        {
            ToggleSwitch();
        }
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
        animator.SetBool("switched",Switched);
        // Flip the sprite based on the movement direction
        if (moveInput > 0)
        {
            if (isChangeSizeBig)
            {
                transform.localScale = Vector3.one * 5;
            }
            else if (isChangeSizeSmall)
            {
                transform.localScale = Vector3.one*2;
            }
            else
            {
                transform.localScale = Vector3.one*3;
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

    private void InteractWithObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 2f);

        if (hit.collider != null && hit.collider.CompareTag("Interactable"))
        {
            Debug.Log("Interacting with " + hit.collider.name);
            // Implement any additional interaction logic here
        }
    }

    private void ToggleSwitch()
    {
        if (Switched)
        {
         
          
            Switched = false;
        }
        else
        {
     
           Switched= true;
        }
    }
    /// <summary>
    /// �Ŵ�С��
    /// </summary>
    private void ToggleSizeBig()
    {
        //�ٴΰ�����ָ�Ϊ������С
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
            groundCheck.transform.localScale = Vector3.one * 5f;
            jumpForce = 12;
            // moveSpeed = 2;
        }
    }
    /// <summary>
    /// ��СС��
    /// </summary>
    private void ToggleSizeSmall()
    {
        //�ٴΰ�����ָ�Ϊ������С
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
            groundCheck.transform.localScale = Vector3.one * 2f;
            jumpForce = 5;
        }
    }
    /// <summary>
    /// �л�Ϊ������С
    /// </summary>
    private void ToggleSizeNormal()
    {
        jumpForce = 10;
        groundCheck.transform.localScale = Vector3.one*3 ;
    }

}
