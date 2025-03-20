using UnityEngine;

public class PContr1 : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private Animator animator;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded = false;
    private bool isWalking = false;
    private bool isRunning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogWarning("Animator bile�eni bulunamad�! Animasyonlar �al��mayacakt�r.");
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (animator != null)
        {
            animator.SetBool("IsJumping", !isGrounded);
        }

        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        isWalking = moveVertical > 0; // **Sadece W tu�una bas�nca y�r�s�n**
        isRunning = isWalking && Input.GetKey(KeyCode.LeftShift); // **Shift bas�l�nca ko�**

        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // **Animasyonlar� g�ncelle**
        if (animator != null)
        {
            animator.SetBool("IsWalking", isWalking && !isRunning); // **Shift yoksa y�r�s�n**
            animator.SetBool("IsRunning", isRunning); // **Shift varsa ko�sun**
        }

        Debug.Log("Walking: " + isWalking + " | Running: " + isRunning);
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.RightControl))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
