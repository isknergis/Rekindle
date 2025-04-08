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
            Debug.LogWarning("Animator bileþeni bulunamadý! Animasyonlar çalýþmayacaktýr.");
        }
    }

    void Update()
    {
        // Zemin kontrolü
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump animasyonu (havada mý kontrolü)
        if (animator != null)
        {
            animator.SetBool("IsJumping", !isGrounded);
        }

        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        isWalking = moveDirection.magnitude > 0f;
        isRunning = isWalking && Input.GetKey(KeyCode.LeftShift);

        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 movement = moveDirection * speed;

        // Rigidbody hareketini uygula (y ekseni korunarak)
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Karakterin yönünü hareket yönüne döndür
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Animasyon parametrelerini güncelle
        if (animator != null)
        {
            animator.SetBool("IsWalking", isGrounded && isWalking && !isRunning);
            animator.SetBool("IsRunning", isGrounded && isRunning);
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.LeftControl))
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
