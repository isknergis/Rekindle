using UnityEngine;

public class PContr2 : MonoBehaviour
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();

        //if (animator == null)
        //{
        //    Debug.LogWarning("Animator bileþeni bulunamadý! Animasyonlar çalýþmayacaktýr.");
        //}
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        //if (animator != null)
        //{
        //    animator.SetBool("IsJumping", !isGrounded);
        //}

        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal_P2");
        float moveVertical = Input.GetAxis("Vertical_P2");

        bool isRunning = Input.GetKey(KeyCode.RightShift);
        float speed = isRunning ? runSpeed : walkSpeed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed;

        // Unity'nin yeni versiyonuna uygun olarak linearVelocity kullanýldý
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
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
